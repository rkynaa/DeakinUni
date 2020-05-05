using System;

namespace Task01
{
    class Tasklist{
        public string catName = "" ;
        public string[] tasks = new string[0];

        public Tasklist(string category){
            this.catName = category;
        }

        public void addTask(string newTask){
            string[] goals = new string[tasks.Length + 1];
            for (int i= 0; i< tasks.Length; i++)
            {
                goals[i] = tasks[i];
            }
            goals[goals.Length - 1] = newTask; 
            tasks = goals;
        }

        public void DisplayData(int i){
            if (tasks.Length > i)
            {
                Console.Write("{0,30}|", tasks[i]);
            }else
            {
                Console.Write("{0,30}|", "N/A");
            }
        }
    }

    class RevisedCode
    {
        public void DisplayData(){

        }


        static void Main(string[] args)
        {
            Tasklist tasksIndividual =  new Tasklist("Personal");
            Tasklist tasksWork = new Tasklist("Work");
            Tasklist tasksFamilly = new Tasklist("Familly");

            while (true)
            {
                Console.Clear();
                int max = tasksIndividual.tasks.Length > tasksWork.tasks.Length ? tasksIndividual.tasks.Length : tasksWork.tasks.Length;
                max = max > tasksFamilly.tasks.Length ? max : tasksFamilly.tasks.Length;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(new string(' ', 12) + "CATEGORIES" + "(Count Max Data =" +max+ ")");

                Console.WriteLine(new string(' ', 10)+new string('-', 94));

                Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", tasksIndividual.catName, tasksWork.catName, tasksFamilly.catName);

                Console.WriteLine(new string(' ', 10) + new string('-', 94));

                for (int i = 0; i < max; i++)
                {
                    Console.Write("{0,10}|", i);

                    tasksIndividual.DisplayData(i);
                    tasksWork.DisplayData(i);
                    tasksFamilly.DisplayData(i);

                    Console.WriteLine();
                }
                
                Console.ResetColor(); 

                Console.WriteLine("\nWhich category do you want to place a new task? Type \'Personal\', \'Work\', or \'Family\'");

                Console.Write(">> "); 

                string listName = Console.ReadLine().ToLower();

                Console.WriteLine("Describe your task below (max. 30 symbols)."); Console.Write(">> ");
                string task = Console.ReadLine(); if (task.Length > 30) task = task.Substring(0, 30);

                if (listName == tasksIndividual.catName.ToLower())
                {
                    tasksIndividual.addTask(task);
                }
                else if (listName == tasksWork.catName.ToLower()) {
                    tasksWork.addTask(task);
                } 
                else if (listName == tasksFamilly.catName.ToLower())
                {
                    tasksFamilly.addTask(task);
                }
            }
        }
    }
}
