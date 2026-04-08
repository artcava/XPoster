# Contributing to XPoster

Thank you for your interest in contributing to XPoster! This document provides guidelines for contributing.

## 🚀 Quick Start

1. **Check existing issues** to avoid duplicates
2. **Open an issue** for bugs or feature requests
3. **Wait for maintainer approval** before starting work
4. **Fork the repository** once approved
5. **Create a branch** from `develop`, following naming conventions
6. **Make your changes** with tests
7. **Submit a Pull Request** targeting `develop` for review

## 👋 Good First Issues

Looking for a good place to start? Check out issues tagged with the `good first issue` label:

➡️ [Browse good first issues](https://github.com/artcava/XPoster/issues?q=label%3A%22good+first+issue%22+is%3Aopen)

These are self-contained tasks with clear acceptance criteria and limited scope — ideal for getting familiar with the codebase.

## 📋 Issue Workflow

### Reporting Bugs

1. Use the **Bug Report** template (`.github/ISSUE_TEMPLATE/bug_report.md`)
2. Provide detailed reproduction steps
3. Wait for `approved` label from maintainer
4. Only then can you start working on it

### Requesting Features

1. Use the **Feature Request** template (`.github/ISSUE_TEMPLATE/feature_request.md`)
2. Explain the problem and proposed solution
3. Wait for maintainer review and approval
4. Feature must be labeled `approved` before development

### Documentation Improvements

1. Use the **Documentation** template (`.github/ISSUE_TEMPLATE/documentation.md`)
2. Reference the file/section that needs updating
3. Suggest the corrected or missing content
4. Wait for maintainer to add the `approved` label before starting work

### Issue Lifecycle

needs-triage → approved → in-progress → needs-review → closed

## 🌿 Branch Naming Convention

> **Always branch off from `develop`. Never branch directly off `master`.**
> This applies to all contribution types, including documentation-only changes.

All branches must follow this pattern:

- `feature/` - New features (e.g., `feature/instagram-integration`)
- `fix/` - Bug fixes (e.g., `fix/twitter-timeout`)
- `hotfix/` - Critical fixes for production (e.g., `hotfix/security-patch`)
- `docs/` - Documentation updates (e.g., `docs/api-guide`)
- `refactor/` - Code refactoring (e.g., `refactor/generator-factory`)
- `test/` - Test additions/updates (e.g., `test/feed-service`)

## 🔀 Pull Request Process

### Before Opening a PR

- [ ] Linked to an **approved** issue
- [ ] Branch name follows conventions
- [ ] Branch was created from `develop` (not `master`)
- [ ] PR targets `develop` (not `master`)
- [ ] All tests pass (`dotnet test`)
- [ ] Code follows project style
- [ ] Documentation updated

### PR Requirements

1. **Fill out the PR template** completely (`.github/PULL_REQUEST_TEMPLATE.md`)
2. **Link to approved issue** using "Closes #123"
3. **Pass all CI checks** (build, tests)
4. **Request review** from @artcava
5. **Address review comments** promptly

### PR Review Process

1. Maintainer reviews code quality
2. Checks tests and documentation
3. May request changes
4. Approves when ready
5. Maintainer merges (you cannot merge)

## 🔐 Secrets Handling

> **⚠️ This section is critical. Read it carefully before your first commit.**

### Never commit secrets

- `src/local.settings.json` is in `.gitignore` — it must **never** be committed.
- Use `src/local.settings.json.example` as the starting template. It contains no real values.
- Never add API keys, tokens, or passwords to any file tracked by Git.

### Setting up local credentials

```bash
# Copy the example file
cp src/local.settings.json.example src/local.settings.json

# Fill in your credentials
code src/local.settings.json
```

See [docs/configuration.md](docs/configuration.md) for the full variable reference.

### Alternative: dotnet user-secrets

For .NET projects that use the `Microsoft.Extensions.Configuration` secrets manager:

```bash
# Initialise user-secrets for the project
dotnet user-secrets init --project src/

# Set a secret
dotnet user-secrets set "X_API_KEY" "your_value" --project src/

# List stored secrets
dotnet user-secrets list --project src/
```

User-secrets are stored outside the repository folder and are never committed.

### If you accidentally commit a secret

1. **Rotate the secret immediately** — assume it is compromised.
2. Remove it from Git history using `git filter-repo` or BFG Repo Cleaner.
3. Force-push the cleaned history (coordinate with maintainer).
4. GitHub Secret Scanning will alert on known token patterns — check the **Security** tab.
5. Notify the maintainer via email (cavallo.marco@gmail.com) so affected services can be audited.

## 🔐 Collaborator Access

To become a collaborator:

1. Contribute quality PRs
2. Show understanding of project architecture
3. Be responsive to feedback
4. Maintain good communication

Collaborators get:
- Write access to create branches
- Ability to label issues
- No merge permissions (maintainer only)

## 💻 Development Setup

**Clone your fork**
```bash
git clone https://github.com/YOUR_USERNAME/XPoster.git
cd XPoster
```

**Add upstream remote**
```bash
git remote add upstream https://github.com/artcava/XPoster.git
```

**Create feature branch from `develop`**
```bash
git checkout develop
git pull upstream develop
git checkout -b feature/your-feature-name
```

**Install dependencies**
```bash
dotnet restore
```

**Run tests**
```bash
dotnet test
```

**Make changes and commit**
```bash
git add .
git commit -m "feat: add new feature"
```

**Push to your fork**
```bash
git push origin feature/your-feature-name
```

## 🧪 Testing Requirements

- All new features must include unit tests
- Maintain or improve code coverage (target: ≥80%)
- Tests must pass before PR approval
- Add integration tests for new integrations

See [tests/README.md](tests/README.md) for the full testing strategy, mocking patterns, and coverage guide.

## 📝 Coding Standards

### C# Style Guide

- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use async/await for asynchronous operations
- Meaningful variable and method names
- Add XML documentation for public APIs
- Keep methods focused (Single Responsibility)

### Commit Messages

Follow [Conventional Commits](https://www.conventionalcommits.org/):

```
feat: add Mastodon integration
fix: resolve Twitter authentication timeout
docs: update API documentation
test: add FeedService unit tests
refactor: simplify GeneratorFactory logic
```

## 🙋 Getting Help

- 💬 [GitHub Discussions](https://github.com/artcava/XPoster/discussions)
- 📧 Email: cavallo.marco@gmail.com
- 📖 [Documentation](docs/index.md)

## 🏆 Recognition

Contributors will be:
- Listed in release notes
- Credited in README
- Mentioned in project updates

Thank you for contributing! 🚀
