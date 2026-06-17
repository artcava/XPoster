# Graphify CI Integration

This document explains how **Graphify** is integrated into the XPoster CI pipeline to automatically generate and maintain an up-to-date code graph of the repository on every push to `main`.

> See also: [Architecture](../architecture.md) — for the overall system design that Graphify helps visualise.

---

## Table of Contents

1. [What is Graphify?](#1-what-is-graphify)
2. [Workflow Overview](#2-workflow-overview)
3. [Backend Graph (graphify-dotnet)](#3-backend-graph-graphify-dotnet)
4. [Frontend Graph (graphify npm package)](#4-frontend-graph-graphify-npm-package)
5. [Output Artefacts](#5-output-artefacts)
6. [How to Trigger Manually](#6-how-to-trigger-manually)
7. [How to Extend](#7-how-to-extend)

---

## 1. What is Graphify?

Graphify is a code-graph generation tool that analyses a codebase and produces a structured representation of its components, dependencies, and relationships. It supports .NET projects via the [`graphify-dotnet`](https://www.nuget.org/packages/graphify-dotnet) global tool and frontend projects via the [`graphifyy`](https://www.npmjs.com/package/graphifyy) npm package.

In XPoster, Graphify is used to keep the `docs/agent-graph/` folder in sync with the actual code structure. This folder is consumed by AI agents and documentation tools to reason about the codebase without reading every source file.

---

## 2. Workflow Overview

The integration lives in `.github/workflows/regenerate-agent-graph.yml`. It runs automatically on every push to `main` that touches backend or frontend source files, and can also be triggered manually via `workflow_dispatch`.

```
Push to main
    │
    ├─► Backend job
    │       dotnet tool install graphify-dotnet
    │       graphify run . --format wiki,report,json
    │       output → docs/agent-graph/backend/
    │
    └─► Frontend job
            bun install
            bun run graphify build .
            output → graphify-out/  →  docs/agent-graph/frontend/
                │
                └─► Commit updated docs/agent-graph/ [skip ci]
```

The workflow uses `concurrency` to cancel any in-progress run if a new push arrives, preventing stale commits.

---

## 3. Backend Graph (graphify-dotnet)

### Installation

The backend tool is installed as a .NET global tool at workflow runtime — no local installation is required:

```yaml
- name: Install graphify-dotnet
  run: dotnet tool install --global graphify-dotnet
```

> **Package name**: [`graphify-dotnet`](https://www.nuget.org/packages/graphify-dotnet) on NuGet.

### Execution

```yaml
- name: Regenerate backend graph
  run: ~/.dotnet/tools/graphify run . --format wiki,report,json --output docs/agent-graph/backend
```

| Flag | Value | Purpose |
|---|---|---|
| `run .` | repository root | Analyses the entire .NET solution |
| `--format wiki,report,json` | three formats | Generates a Markdown wiki, a human-readable report, and a machine-readable JSON graph |
| `--output` | `docs/agent-graph/backend` | Destination folder for all output files |

---

## 4. Frontend Graph (graphify npm package)

### Installation

The frontend package is installed as part of the normal `pnpm install` step. No separate installation step is needed — `graphify` is declared as a `devDependency` in `frontend/package.json`.

> **Package name**: [`graphifyy`](https://www.npmjs.com/package/graphifyy) on npm (note the double `y`).
> The CLI command exposed is `graphify`.

### Execution

```yaml
- name: Regenerate frontend graph
  working-directory: frontend
  run: bun run graphify build .
```

Graphify writes its output to `frontend/graphify-out/`. A subsequent step moves it to the canonical docs location:

```yaml
- name: Move frontend graph output
  run: |
    rm -rf docs/agent-graph/frontend
    mkdir -p docs/agent-graph/frontend
    cp -r frontend/graphify-out docs/agent-graph/frontend
```

---

## 5. Output Artefacts

All generated files are committed to `docs/agent-graph/` and versioned in the repository:

```
docs/agent-graph/
├── backend/
│   ├── wiki.md          ← Human-readable component wiki
│   ├── report.md        ← Dependency and coupling report
│   └── graph.json       ← Machine-readable dependency graph
└── frontend/
    └── graphify-out/    ← Frontend graph output (structure depends on graphify version)
```

The commit is made by the `github-actions[bot]` user with the message `docs(graph): regenerate agent graph [skip ci]` to prevent a CI loop.

---

## 6. How to Trigger Manually

1. Go to **Actions** → **Regenerate Agent Graph** in the GitHub UI.
2. Click **Run workflow** → select the branch → **Run workflow**.

Or via CLI:

```bash
gh workflow run regenerate-agent-graph.yml --ref main
```

---

## 7. How to Extend

| Goal | What to change |
|---|---|
| Add a new output format for the backend | Add the format name to `--format wiki,report,json,...` in the workflow step |
| Change the output directory | Update `--output` in the backend step and the `cp -r` path in the move step |
| Analyse only a subfolder | Replace `.` with the relative path (e.g. `src/`) in the `graphify run` command |
| Run on pull requests too | Add `pull_request:` to the `on:` block in the workflow file |
| Pin the graphify-dotnet version | Use `dotnet tool install --global graphify-dotnet --version X.Y.Z` |
