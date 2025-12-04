![Notepad App Icon](https://copilot.microsoft.com/th/id/BCO.78c8d9a3-dd36-436f-ae14-418b09a48a4c.png)


📝 Notepad Clone – Windows Forms Edition

A feature-rich Notepad-style text editor built with Windows Forms in C#. This application replicates and extends core functionality of classic Notepad, offering a modern interface, multi-form architecture, and essential editing tools.

---

📦 Features

- Main Editor (Form1):
  - Rich text editing with undo/redo stack logic
  - Cut, copy, paste, select all
  - Font and color customization via dialogs
  - Status bar with live character count
  - Save, Save As, Open, and New document handling
  - UTF-8 and ASCII encoding support
  - Print functionality with multi-page support

- About Form (Form2):
  - Displays app credits and author information
  - Triggered via the "About" menu item

- Find & Replace Form (Form3):
  - Search for words with case-insensitive matching
  - Replace selected word or all occurrences
  - Tracks last search index for "Find Next"
  - Error messages and input validation

---

🛠 Technologies Used

- Language: C#
- Framework: .NET Framework (Windows Forms)
- IDE: Visual Studio
- UI Components: TextBox, MenuStrip, Dialogs, Labels, Buttons, Panels

---

🚀 How to Run

1. Clone or download the repository.
2. Open the solution in Visual Studio.
3. Build and run the project.
4. Use the menu bar to access editing tools, file operations, and additional forms.

---

📁 Project Structure

`
notepad/
├── Form1.cs              // Main editor logic and UI
├── Form2.cs              // About form
├── Form3.cs              // Find & Replace form
├── Program.cs            // Application entry point
├── Resources/            // Icons, fonts, and other assets
`

---

💡 Educational Value

This project demonstrates:

- Multi-form communication and UI design
- Stack-based undo/redo implementation
- File I/O with encoding options
- Dialog-driven customization (font, color)
- Modular design for maintainability and extensibility
