using System;
using System.Collections.Generic;

namespace Task01
{
    class NewTasklist{
        public string catName = "" ;
        public List<string> tasks = new List<string>();
        public List<string> importance = new List<string>(); //values : normal or important
        public List<DateTime> dueDates = new List<DateTime>();
        public NewTasklist(string category){
            this.catName = category;
        }

        public void addTask(string newTask, string importanceLevel){
            tasks.Add(newTask);
            importance.Add(importanceLevel);
            dueDates.Add(System.DateTime.MinValue);
        }

        public void deleteTaskByIndex(int idx){
            if (idx < tasks.Count)
            {
                tasks.RemoveAt(idx);
                importance.RemoveAt(idx);
                dueDates.RemoveAt(idx);
            }else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please Input valid index number!");
            }
            
        }

        public void deleteTaskByName(string task){
            int idx = tasks.IndexOf(task);
            if (tasks.Remove(task))
            {
                importance.RemoveAt(idx);
                dueDates.RemoveAt(idx);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Task with name :"+task+" not found!");
            }
        }

        public void moveListTo(int oldIdx, int newIdx){
            //
        }
        public void DisplayData(int i){
            if (tasks.Count > i)
            {   
                if (importance[i] == "important"){
                    Console.ForegroundColor = ConsoleColor.Red;
                }else{
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                if (dueDates[i] != System.DateTime.MinValue){
                    Console.Write("{0,40}|", tasks[i]+":"+dueDates[i].ToString("yyyy-MM-dd"));
                }else{
                    Console.Write("{0,40}|", tasks[i]);
                }
                
            }else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("{0,40}|", "N/A");
            }
        }
    }

    class CategoryTask{
        public List<NewTasklist> catList = new List<NewTasklist>();
        public List<string> catListName = new List<string>();
        public CategoryTask(){

        }

        public void AddCategoryTask(NewTasklist aTaskList){
            catList.Add(aTaskList);
            catListName.Add(aTaskList.catName);
        }

        public void RemoveCategoryByName(string aCatName){
            int idx = catListName.IndexOf(aCatName);
            if (idx != -1){
                catList.RemoveAt(idx);
                catListName.RemoveAt(idx);
            }
        }

        public void DeleteATaskById(string aCatName, int idxTask){
            int idx = catListName.IndexOf(aCatName);
            if (idx != -1){
                catList[idx].deleteTaskByIndex(idxTask);
            }
        }

        public void changeTaskImportanceLevel(string aCatName, int idxTask, string importanceLevel){
            int idx = catListName.IndexOf(aCatName);
            if (idx != -1){
                catList[idx].importance[idxTask] = importanceLevel;
            }
        }
        
        public int getMaxCount(){
            int result = 0;
            for (int i=0; i < catList.Count; i++){
                if (i == 0){
                    result = catList[i].tasks.Count;
                }else{
                    result = result > catList[i].tasks.Count ? result : catList[i].tasks.Count;
                }
            }
            return result;
        }

        public void AddTaskToList(string categoryName,string newTask, string importanceLevel){
            int idx = catListName.IndexOf(categoryName);
            if (idx != -1){
                catList[idx].addTask(newTask, importanceLevel);
            }else{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Categoty with name :"+categoryName+" not found!");    
            }
        }

        public void AddDueDate(string aCatName, int idxTask, DateTime dueDate){
            int idx = catListName.IndexOf(aCatName);
            if (idx != -1){
                catList[idx].dueDates[idxTask] = dueDate;
            }
        }
    }
    class FinalCode
    {
        
        static void Main(string[] args)
        {
            bool firstInputDone = false;
            String featureSelected = "0";
            int dashCount = 4;

            CategoryTask categories = new CategoryTask();

            while (true)
            {
                Console.Clear();

                int max = categories.getMaxCount(); 
                if (categories.catList.Count > 0){
                    dashCount = 4 + (40 * categories.catList.Count);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string(' ', 12) + "CATEGORIES" + "(Count Max Data =" +max+ ")");

                    Console.WriteLine(new string(' ', 10)+new string('-', dashCount));

                    
                    Console.Write("{0,10}|","item #");
                    for (int i=0; i < categories.catList.Count; i++){
                        Console.Write("{0,40}|",categories.catListName[i]);
                    }

                    Console.WriteLine();
                    Console.WriteLine(new string(' ', 10) + new string('-', dashCount));
                     
                    for (int i = 0; i < max; i++)
                    {
                        Console.Write("{0,10}|", i);

                        for (int j =0; j<categories.catList.Count; j++){
                            categories.catList[j].DisplayData(i);
                        }

                        Console.WriteLine();
                    }

                    Console.ResetColor(); 
                    Console.WriteLine("\nINPUT FEATURE NUMBER TO OPERATE :");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1. Add new task");
                    Console.WriteLine("2. Delete a task");
                    Console.WriteLine("3. Change a task importance level");
                    Console.WriteLine("4. Add new category");
                    Console.WriteLine("5. Delete a category");
                    Console.WriteLine("6. Add Due date to a task");
                    Console.WriteLine("0. Exit Application");
                    Console.WriteLine();
                    
                    Console.Write(">> "); 
                    featureSelected = Console.ReadLine();
                    switch (featureSelected){
                        case "1":
                            Console.ResetColor();
                            Console.WriteLine("\nWhich category do you want to place a new task? Type Category Name (Look at table header)");

                            Console.Write(">> "); 

                            string listName = Console.ReadLine().ToLower();

                            Console.WriteLine("Describe your task below (max. 30 symbols)."); 
                            Console.Write(">> ");
                            string task = Console.ReadLine(); 
                            
                            Console.WriteLine("Set Importance Level for your task (normal / important)."); 
                            Console.Write(">> ");   
                            string il = Console.ReadLine();
                            
                            if (task.Length > 30) task = task.Substring(0, 30);

                            categories.AddTaskToList(listName, task, il);
                            break;
                        case "2":
                            Console.ResetColor();
                            Console.WriteLine("\nWhich category do you want to delete a task? Type Category Name (Look at table header)");

                            Console.Write(">> "); 

                            string _catName = Console.ReadLine().ToLower();
                            Console.WriteLine("Input ID of a Task you want to delete :"); 
                            Console.Write(">> ");
                            string taskId = Console.ReadLine();

                            categories.DeleteATaskById(_catName,int.Parse(taskId));

                            break;
                        case "3":
                            Console.ResetColor();
                            Console.WriteLine("\nWhich category do you want to Change? Type Category Name (Look at table header)");

                            Console.Write(">> "); 

                            string catNameToChange = Console.ReadLine().ToLower();
                            Console.WriteLine("Input ID of a Task you want to Change :"); 
                            Console.Write(">> ");
                            int taskIdToChange = int.Parse(Console.ReadLine());

                            Console.WriteLine("Input importance level (normal / important) :"); 
                            Console.Write(">> ");
                            string ilToChange = Console.ReadLine();

                            categories.changeTaskImportanceLevel(catNameToChange, taskIdToChange, ilToChange);
                            break;
                        case "4":
                            Console.ResetColor(); 
                            Console.WriteLine("\nNew Category Name");
                            Console.Write(">> "); 
                            string newCatName = Console.ReadLine().ToLower();
                            categories.AddCategoryTask(new NewTasklist(newCatName)); 
                            break;
                        case "5":
                            Console.ResetColor();
                            Console.WriteLine("\nWhich category do you want to delete?");
                            Console.Write(">> ");
                            string catToDelete= Console.ReadLine();
                            categories.RemoveCategoryByName(catToDelete);
                            break;
                        case "6":
                            Console.ResetColor();
                            Console.WriteLine("\nWhich category do you want to add due date? Type Category Name (Look at table header)");
                            Console.Write(">> "); 
                            string catNameDD = Console.ReadLine().ToLower();
                            Console.WriteLine("Input ID of a Task you want to add due date :"); 
                            Console.Write(">> ");
                            int taskIdDD = int.Parse(Console.ReadLine());

                            Console.WriteLine("Input due date (yyyy-MM-dd) :"); 
                            Console.Write(">> ");
                            DateTime DD = DateTime.Parse(Console.ReadLine());

                            categories.AddDueDate(catNameDD, taskIdDD, DD);
                            break;
                    }

                    

                }
                else{
                    while (!firstInputDone){
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("WELCOME TO TASK MANAGER @BUGGYSOFT 2020");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Please Input Several categories for first use");
                        Console.WriteLine("type \'Done\' When Finish");
                        Console.WriteLine("\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (categories.catList.Count > 0){
                            for (int i=0; i<categories.catList.Count; i++){
                                Console.WriteLine((i+1)+" . "+categories.catListName[i]);
                            }
                        }
                        Console.ResetColor(); 
                        Console.WriteLine("\nNew Category Name");

                        Console.Write(">> "); 

                        string _catName = Console.ReadLine().ToLower();
                        if (_catName.ToLower() != "done" ){
                            categories.AddCategoryTask(new NewTasklist(_catName));
                        }else{
                            firstInputDone = true;
                            break;
                        }
                    }
                }                 
            }
        }
    }
}
