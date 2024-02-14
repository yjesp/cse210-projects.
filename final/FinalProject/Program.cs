from datetime import datetime

class Task:
    def __init__(self, title="", description="", due_date=None):
        self.title = title
        self.description = description
        self.due_date = due_date
        self.is_complete = False

    def set_title(self, title):
        self.title = title

    def set_description(self, description):
        self.description = description

    def set_due_date(self, due_date):
        self.due_date = due_date

    def mark_as_complete(self):
        self.is_complete = True

class TaskList:
    def __init__(self):
        self.tasks = []

    def add_task(self, task):
        self.tasks.append(task)

    def remove_task(self, task):
        self.tasks.remove(task)

    def get_tasks(self):
        return self.tasks

class User:
    def __init__(self, username="", password=""):
        self.username = username
        self.password = password

    def set_username(self, username):
        self.username = username

    def set_password(self, password):
        self.password = password

    def authenticate(self, username, password):
        return self.username == username and self.password == password

class Menu:
    @staticmethod
    def display_main_menu():
        print("Main Menu:")
        print("1. Manage Tasks")
        print("2. Exit")

    @staticmethod
    def display_task_menu():
        print("Task Menu:")
        print("1. Add Task")
        print("2. Remove Task")
        print("3. Mark Task as Complete")
        print("4. View Tasks")
        print("5. Back to Main Menu")

class InputHandler:
    @staticmethod
    def get_user_input(prompt):
        return input(prompt)


# Sample interaction
if __name__ == "__main__":
    task_list = TaskList()
    user = User()

    while True:
        Menu.display_main_menu()
        choice = InputHandler.get_user_input("Enter your choice: ")

        if choice == "1":
            while True:
                Menu.display_task_menu()
                task_choice = InputHandler.get_user_input("Enter your choice: ")

                if task_choice == "1":
                    title = InputHandler.get_user_input("Enter task title: ")
                    description = InputHandler.get_user_input("Enter task description: ")
                    due_date_str = InputHandler.get_user_input("Enter due date (YYYY-MM-DD): ")
                    due_date = datetime.strptime(due_date_str, "%Y-%m-%d")
                    task = Task(title, description, due_date)
                    task_list.add_task(task)
                    print("Task added successfully.")
                elif task_choice == "2":
                    # Implement remove task functionality
                    pass
                elif task_choice == "3":
                    # Implement mark task as complete functionality
                    pass
                elif task_choice == "4":
                    tasks = task_list.get_tasks()
                    for task in tasks:
                        print(f"Title: {task.title}, Description: {task.description}, Due Date: {task.due_date}, Complete: {task.is_complete}")
                elif task_choice == "5":
                    break
                else:
                    print("Invalid choice. Please try again.")
        elif choice == "2":
            print("Exiting...")
            break
        else:
            print("Invalid choice. Please try again.")
