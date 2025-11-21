# Contributing to XPoster

Thank you for your interest in contributing to XPoster! This document provides guidelines for contributing.

## 🚀 Quick Start

1. **Check existing issues** to avoid duplicates
2. **Open an issue** for bugs or feature requests
3. **Wait for maintainer approval** before starting work
4. **Fork the repository** once approved
5. **Create a branch** following naming conventions
6. **Make your changes** with tests
7. **Submit a Pull Request** for review

## 📋 Issue Workflow

### Reporting Bugs

1. Use the **Bug Report** template
2. Provide detailed reproduction steps
3. Wait for `approved` label from maintainer
4. Only then can you start working on it

### Requesting Features

1. Use the **Feature Request** template
2. Explain the problem and proposed solution
3. Wait for maintainer review and approval
4. Feature must be labeled `approved` before development

### Issue Lifecycle

needs-triage → approved → in-progress → needs-review → closed

## 🌿 Branch Naming Convention

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
- [ ] All tests pass (`dotnet test`)
- [ ] Code follows project style
- [ ] Documentation updated

### PR Requirements

1. **Fill out the PR template** completely
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
git clone https://github.com/YOUR_USERNAME/XPoster.git
cd XPoster

**Add upstream remote**
git remote add upstream https://github.com/artcava/XPoster.git

**Create feature branch**
git checkout -b feature/your-feature-name

**Install dependencies**
dotnet restore

**Run tests**
dotnet test

**Make changes and commit**
git add .
git commit -m "feat: add new feature"

**Push to your fork**
git push origin feature/your-feature-name


## 🧪 Testing Requirements

- All new features must include unit tests
- Maintain or improve code coverage
- Tests must pass before PR approval
- Add integration tests for new integrations

## 📝 Coding Standards

### C# Style Guide

- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use async/await for asynchronous operations
- Meaningful variable and method names
- Add XML documentation for public APIs
- Keep methods focused (Single Responsibility)

### Commit Messages

Follow [Conventional Commits](https://www.conventionalcommits.org/):

feat: add Mastodon integration
fix: resolve Twitter authentication timeout
docs: update API documentation
test: add FeedService unit tests
refactor: simplify GeneratorFactory logic


## 🙋 Getting Help

- 💬 [GitHub Discussions](https://github.com/artcava/XPoster/discussions)
- 📧 Email: cavallo.marco@gmail.com
- 📖 [Documentation](https://github.com/artcava/XPoster/wiki)

## 🏆 Recognition

Contributors will be:
- Listed in release notes
- Credited in README
- Mentioned in project updates

Thank you for contributing! 🚀
