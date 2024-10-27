## **Git Commands**

[Return to README](README.md)

### 1. **Initialize a Repository**  
Sets up a new local Git repository.
```bash
git init
```

---

### 2. **Clone a Repository**  
Copies an existing repository to your local machine.
```bash
git clone <repository-url>
```

---

### 3. **Check Repository Status**  
Displays the status of tracked and untracked files.
```bash
git status
```

---

### 4. **Stage Changes (Add Files)**  
Stages files for the next commit.  
- **Single file:**
  ```bash
  git add <file-name>
  ```
- **All changes:**
  ```bash
  git add .
  ```

---

### 5. **Commit Changes**  
Creates a new commit with staged changes.
```bash
git commit -m "Your commit message"
```

---

### 6. **View Commit History**  
Shows the commit history with details.
```bash
git log
```
- **Compact view:**
  ```bash
  git log --oneline
  ```

---

### 7. **Create a New Branch**  
Creates a new branch from the current branch.
```bash
git branch <branch-name>
```

---

### 8. **Switch Branches**  
Moves to a different branch.
```bash
git checkout <branch-name>
```
- **Or using the new command:**  
  ```bash
  git switch <branch-name>
  ```

---

### 9. **Merge Branches**  
Merges a branch into the current branch.
```bash
git merge <branch-name>
```

---

### 10. **Push Changes to GitHub**  
Sends local commits to the remote repository.
```bash
git push origin <branch-name>
```
- **Push to the default branch:**
  ```bash
  git push
  ```

---

### 11. **Pull Changes from GitHub**  
Downloads and integrates changes from the remote repository.
```bash
git pull
```

---

### 12. **Resolve Merge Conflicts**  
When conflicts occur during merging or pulling, edit the conflicted files manually, stage the resolved files, and commit:
```bash
git add .
git commit -m "Resolved conflicts"
```

---

### 13. **Stash Changes**  
Temporarily saves changes you don’t want to commit yet.
```bash
git stash
```
- **Apply the stash later:**  
  ```bash
  git stash apply
  ```

---

### 14. **Remove a File from Tracking**  
Stops tracking a file but keeps it locally.
```bash
git rm --cached <file-name>
```

---

### 15. **Delete a Local Branch**  
Deletes a branch from your local repository.
```bash
git branch -d <branch-name>
```

---

### 16. **Undo Last Commit (Keep Changes)**  
Reverts the last commit but keeps the changes in your working directory.
```bash
git reset --soft HEAD~1
```

---

### 17. **Undo Changes in a File**  
Resets a file to the last committed version.
```bash
git checkout -- <file-name>
```

---

### 18. **Tag a Commit**  
Tags a specific commit (for releases).
```bash
git tag -a v1.0 -m "Version 1.0"
git push origin v1.0
```

---

### 19. **Add a Remote Repository**  
Links a remote repository to your local repo.
```bash
git remote add origin <repository-url>
```

---

### 20. **View Remote Repositories**  
Lists all remote repositories.
```bash
git remote -v
```