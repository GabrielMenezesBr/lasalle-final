## **GitHub Commands**

[Return to README](README.md)

### 1. **Fork a Repository**  
- Go to the repository on **GitHub** and click the **Fork** button to create your own copy.

---

### 2. **Create a Pull Request**  
After making changes on a branch, push them to your fork and create a **Pull Request (PR)** via the GitHub UI.

---

### 3. **Clone a Forked Repository**  
To work on a forked repository:
```bash
git clone <forked-repo-url>
git remote add upstream <original-repo-url>
```

---

### 4. **Sync Forked Repository with Original**  
Pull new changes from the original repository.
```bash
git fetch upstream
git merge upstream/main
```

---

## **Common Git Aliases for Efficiency**
You can add aliases in Git to speed up your workflow:
```bash
git config --global alias.co checkout
git config --global alias.br branch
git config --global alias.ci commit
git config --global alias.st status
```
Now, you can use commands like:
```bash
git co <branch>    # Instead of 'git checkout'
git br             # Instead of 'git branch'
```

---

## **Useful Tips and Best Practices**

1. **.gitignore Files:**  
   Create a `.gitignore` file to prevent tracking of certain files (e.g., `.env`, `node_modules`).

   Example `.gitignore`:
   ```
   node_modules/
   .env
   dist/
   ```

2. **Sign Your Commits:**  
   Use GPG to sign commits for better security:
   ```bash
   git commit -S -m "Signed commit"
   ```

3. **Use SSH for GitHub:**  
   Set up SSH authentication for easier access to repositories:
   ```bash
   ssh-keygen -t rsa -b 4096 -C "your-email@example.com"
   ```

4. **Interactive Rebase:**  
   Use interactive rebase to clean up commits before pushing:
   ```bash
   git rebase -i HEAD~3
   ```

5. **Use GitHub CLI (gh):**  
   The GitHub CLI helps manage repositories directly from the terminal:
   ```bash
   gh repo clone <repository>
   gh issue create
   gh pr create
   ```