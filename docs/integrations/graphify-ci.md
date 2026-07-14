# Graphify CI Integration

This document explains how **Graphify** is integrated into the XPoster CI pipeline to automatically generate and maintain an up-to-date code graph of the repository on every merge to `develop`.

> See also: [Architecture](../architecture.md) — for the overall system design that Graphify helps visualise.

---

## Table of Contents

1. [What is Graphify?](#1-what-is-graphify)
2. [Workflow Overview](#2-workflow-overview)
3. [Graph Generation (graphify-dotnet)](#3-graph-generation-graphify-dotnet)
4. [Output Artefacts](#4-output-artefacts)
5. [How to Trigger Manually](#5-how-to-trigger-manually)
6. [How to Extend](#6-how-to-extend)

---

## 1. What is Graphify?

Graphify is a code-graph generation tool that analyses a codebase and produces a structured representation of its components, dependencies, and relationships. It supports .NET projects via the [`graphify-dotnet`](https://www.nuget.org/packages/graphify-dotnet) global tool.

In XPoster, Graphify is used to keep the `docs/agent-graph/` folder in sync with the actual code structure. This folder is consumed by AI agents and documentation tools to reason about the codebase without reading every source file.

> XPoster is a serverless Azure Function with no frontend surface. Only the .NET codebase is analysed.

---

## 2. Workflow Overview

The active integration lives in `.github/workflows/persist-agent-graph.yml`. It runs automatically on every push to `develop` (i.e. after a PR is merged) that does not exclusively touch `docs/agent-graph/` itself, and can also be triggered manually via `workflow_dispatch`.

```
Push to develop (post-merge)
    │
    └─► persist job
            dotnet tool install graphify-dotnet
            graphify run . --format wiki,report,json
            output → docs/agent-graph/
            generate docs/agent-graph/NOTICE.md
            git commit + push to develop [skip ci]
```

**Loop prevention:** the workflow ignores pushes that only touch `docs/agent-graph/**`, so the commit it produces does not re-trigger it. The commit message also includes `[agent-graph-sync]` to suppress `ci.yml` on that docs-only push.

**Authentication:** the workflow uses a `BOT_PAT` fine-grained personal access token (Contents: Read & Write) stored as a repository secret. `GITHUB_TOKEN` is rejected with 403 on the protected `develop` branch.

> **Note — `regenerate-agent-graph.yml`:** A second workflow exists in `.github/workflows/regenerate-agent-graph.yml` and was designed to run as a PR check, generating a preview artifact without committing. It is currently **disabled**. All graph generation and persistence is handled exclusively by `persist-agent-graph.yml`.

---

## 3. Graph Generation (graphify-dotnet)

### Installation

The tool is installed as a .NET global tool at workflow runtime — no local installation is required:

```yaml
- name: Install graphify-dotnet
  run: dotnet tool install --global graphify-dotnet
```

> **Package name**: [`graphify-dotnet`](https://www.nuget.org/packages/graphify-dotnet) on NuGet.

### Execution

```yaml
- name: Regenerate agent graph (code + docs + infra)
  run: |
    ~/.dotnet/tools/graphify run . \
      --format wiki,report,json \
      --output docs/agent-graph
```

| Flag | Value | Purpose |
|---|---|---|
| `run .` | repository root | Analyses the entire .NET solution including `src/`, `tests/`, `docs/`, and `infra/` |
| `--format wiki,report,json` | three formats | Generates a Markdown wiki, a human-readable report, and a machine-readable JSON graph |
| `--output` | `docs/agent-graph` | Destination folder for all output files |

---

## 4. Output Artefacts

All generated files are committed directly to `develop` in `docs/agent-graph/` and versioned in the repository:

```
docs/agent-graph/
├── wiki.md       ← Human-readable component wiki
├── report.md     ← Dependency and coupling report
├── graph.json    ← Machine-readable dependency graph
└── NOTICE.md     ← Auto-generated LLM content-type annotation
```

**`NOTICE.md`** annotates each node type (source code, documentation, infrastructure, generated) so that AI agents consuming the graph can correctly interpret the nature of each node without reading every file.

The commit is made by the `github-actions[bot]` user (authenticated via `BOT_PAT`) with the message `docs(graph): regenerate agent graph [agent-graph-sync]`. If the graph has not changed since the last run, no commit is produced.

---

## 5. How to Trigger Manually

1. Go to **Actions** → **Persist Agent Graph** in the GitHub UI.
2. Click **Run workflow** → select `develop` → **Run workflow**.

Or via CLI:

```bash
gh workflow run persist-agent-graph.yml --ref develop
```

---

## 6. How to Extend

| Goal | What to change |
|---|---|
| Add a new output format | Add the format name to `--format wiki,report,json,...` in the workflow step |
| Change the output directory | Update `--output` in the generation step and the `git add` path in the commit step |
| Analyse only a subfolder | Replace `.` with the relative path (e.g. `src/`) in the `graphify run` command |
| Pin the graphify-dotnet version | Use `dotnet tool install --global graphify-dotnet --version X.Y.Z` |
| Extend the NOTICE.md content | Edit the `Generate LLM content-type notice` step in `persist-agent-graph.yml` |
