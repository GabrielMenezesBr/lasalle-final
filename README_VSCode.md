## **Essential VSCode Commands**

[Return to README](README.md)

1. **Open a Folder or File:**
   ```bash
   code .
   ```
   - Opens the current directory in VSCode.  
   - Use `code <file-name>` to open a specific file.

2. **Install an Extension:**
   - Press **`Ctrl + Shift + P`** and run:
     ```
     ext install <extension-name>
     ```
   - Example: `ext install ms-python.python` installs the Python extension.

3. **Open Command Palette:**
   - **`Ctrl + Shift + P`** (Windows/Linux) or **`Cmd + Shift + P`** (Mac).  
   This is your gateway to all commands available in VSCode.

---

## **Keyboard Shortcuts for VSCode**

### 1. **Basic File & Editor Management**
- **Open Command Palette:**  
  **`Ctrl + Shift + P`** / **`Cmd + Shift + P`** (Mac)  
- **Open New File:**  
  **`Ctrl + N`** / **`Cmd + N`**  
- **Open File Explorer:**  
  **`Ctrl + Shift + E`** / **`Cmd + Shift + E`**  
- **Switch Between Open Tabs:**  
  **`Ctrl + Tab`** / **`Cmd + Tab`**  
- **Split Editor:**  
  **`Ctrl + \`** / **`Cmd + \`**  
- **Close Editor Tab:**  
  **`Ctrl + W`** / **`Cmd + W`**

---

### 2. **Editing Code**
- **Format Code:**  
  **`Shift + Alt + F`** / **`Shift + Option + F`** (Mac)  
- **Copy Line Up/Down:**  
  **`Alt + Shift + Up/Down`** / **`Option + Shift + Up/Down`** (Mac)  
- **Move Line Up/Down:**  
  **`Alt + Up/Down`** / **`Option + Up/Down`**  
- **Comment/Uncomment Line:**  
  **`Ctrl + /`** / **`Cmd + /`**  
- **Select the Same Word Across the File:**  
  **`Ctrl + D`** / **`Cmd + D`**  
- **Select All Occurrences of Word:**  
  **`Ctrl + Shift + L`** / **`Cmd + Shift + L`**  

---

### 3. **Navigating Code Efficiently**
- **Go to File:**  
  **`Ctrl + P`** / **`Cmd + P`** (Quick open)  
- **Go to Definition:**  
  **`F12`** / **`Cmd + Click`** (Mac)  
- **Peek Definition:**  
  **`Alt + F12`** / **`Option + F12`** (Mac)  
- **Go to Symbol in File:**  
  **`Ctrl + Shift + O`** / **`Cmd + Shift + O`**  
- **Go to Line Number:**  
  **`Ctrl + G`** / **`Cmd + G`**  

---

### 4. **Terminal Shortcuts**
- **Open Integrated Terminal:**  
  **`Ctrl + \``** / **`Cmd + \``** (Backtick key)  
- **Switch Between Open Terminals:**  
  **`Ctrl + Shift + [ or ]`** / **`Cmd + Shift + [ or ]`**  
- **Kill the Current Terminal:**  
  **`Ctrl + C`**  

---

## **Productivity Tips for VSCode**

1. **Sync Your Settings Across Devices**  
   - Sign in with your **GitHub** or **Microsoft** account under **Settings > Turn on Settings Sync**.

2. **Use Live Server for Web Development**  
   - Install the **Live Server** extension.  
   - Right-click your HTML file and choose **Open with Live Server** to see changes instantly.

3. **Extensions to Boost Productivity:**
   - **Prettier**: Code formatter.  
   - **ESLint**: Linter for JavaScript.  
   - **Bracket Pair Colorizer**: Highlights matching brackets.  
   - **GitLens**: Provides Git insights directly in the code.

4. **Zen Mode for Focused Coding**  
   - Toggle **Zen Mode** with **`Ctrl + K Z`** / **`Cmd + K Z`**.  
   - Hides sidebars and distractions for a focused environment.

5. **Emmet Shortcuts for HTML & CSS**  
   - Type a tag shortcut (e.g., `div.container`) and press **`Tab`** to expand it into HTML code.

6. **Use Snippets for Repeated Code**  
   - Create your own snippets under **File > Preferences > User Snippets**.  
   - Example: Create a snippet for quickly writing React components.

7. **Multi-Cursor Editing**  
   - Press **`Alt + Click`** / **`Option + Click`** (Mac) to add multiple cursors and edit multiple places at once.

8. **Integrated Git Controls**  
   - Open the **Source Control** view with **`Ctrl + Shift + G`** / **`Cmd + Shift + G`**.  
   - Use inline actions to commit, push, or pull directly from VSCode.

---

### **Useful Settings to Customize VSCode**  
You can access and edit settings by opening the **Settings JSON** file:  
1. Press **`Ctrl + Shift + P`** / **`Cmd + Shift + P`**.  
2. Search for **Preferences: Open Settings (JSON)**.

Here are a few common settings to tweak:  
```json
{
  "editor.fontSize": 14,
  "editor.tabSize": 2,
  "editor.wordWrap": "on",
  "workbench.colorTheme": "Monokai",
  "files.autoSave": "onFocusChange"
}
```