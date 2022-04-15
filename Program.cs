using System;

namespace Functions1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] fullName = { "Фамилия Имя Отчество","Иванов Иван Иванович","Сидоров Сидр Сидорович","Тихонов Тихон Тихонович","Самсонов Самсон Самсонович" };
            string[] positions = { "Должность","Суетолог","Мамолог","Технолог","Слесарь" };
            
            Console.Clear();
            OutputMenu();

            bool isContinueProgram = true;

            while(isContinueProgram)
            {
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case"добавить":

                        AddDossier(ref fullName, ref positions);

                        break;
                    case "вывести":

                        ShowDossier(fullName, positions);

                        break;
                    case "удалить":

                        DeleteDossier(ref fullName, ref positions);

                        break;
                    case "найти":
                         
                        IsPersonInDossier(fullName, positions);

                        break;
                    case "закрыть":
                        
                        isContinueProgram = false;

                        break;
                    default:

                        DefaultMesadge(fullName, positions);

                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullName, ref string[] positions)
        {

            Console.Write("Введите фамилию - ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя - ");
            string name = Console.ReadLine();
            Console.Write("Введите отчество - ");
            string patronymic = Console.ReadLine();
            Console.Write("Введите должность - ");
            string position = Console.ReadLine();
            Console.WriteLine();

            string tempString = lastName + " " + name + " " + patronymic;
            int increment = 1;

            fullName = SaveArray(fullName, fullName.Length + increment, tempString);
            positions = SaveArray(positions, positions.Length + increment, position);
            DefaultMesadge(fullName, positions);
        }

        static void DefaultMesadge(string[] fullName,string[] positions)
        {
            Console.Clear();
            OutputMenu();
            ShowDossier(fullName, positions);
        }

        static void OutputMenu()
        {
            Console.WriteLine("Для вывода данных работника наберите       - вывести");
            Console.WriteLine("Для добавления даных работника наберите    - добавить");
            Console.WriteLine("Удаления работника из базы данных наберите - удалить");
            Console.WriteLine("Для закрыти программы наберите             - закрыть");
            Console.WriteLine("Для поиска работника наберите              - найти");
        }

        static void ShowDossier(string[] fullName, string[] positions)
        {

            Console.WriteLine();
            for(int i =0;i<fullName.Length;i++)
            {
                if(i!=0)
                {
                    Console.WriteLine(i+" " + fullName[i] + " " + positions[i]);
                }
                else
                {
                    Console.WriteLine("  " + fullName[i] + " " + positions[i]);
                }
            }
        }

        static void DeleteDossier(ref string[]fullName,ref string[]positions)
        {
            int userInput=0;

            bool bb = true;

            while(bb)
            {
            Console.Write("Для удаления работника введите его номер - ");
            string temp = Console.ReadLine();

                for(int i=0;i<temp.Length;i++)
                {
                    if(char.IsNumber(temp,i))
                    {
                        if ((temp.Length-1)==i)
                        {
                            userInput = int.Parse(temp);
                            if(userInput<(fullName.Length))
                            {
                                bb = false;
                            }else
                            {
                                Console.WriteLine("Вы ввели не корректный номер");
                                temp = "";
                                userInput = 0;
                            }
                        }
                    }else
                    {
                        temp = "";
                        Console.Write("Для указания работника используйте только номер ");
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine();

            int increment = -1;

            fullName = SaveArray(fullName, fullName.Length + increment, userInput);
            positions = SaveArray(fullName, positions.Length + increment, userInput);

            DefaultMesadge(fullName, positions);
        }

        static bool IsPersonInDossier(string[] fullName, string[] positions)
        {
            bool IsPerson = false;
            Console.Write("Для поиска работника введите фамилию - ");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            int tempI = 0;
            
            for (int i = 0; i < fullName.Length; i++)
            {

                if (userInput == fullName[i].Split(' ')[0])
                {
                    IsPerson = true;
                    tempI = i;
                }
            }

            if (IsPerson==true)
            {
                Console.WriteLine(fullName[tempI] + " - " + positions[tempI]);
            }else
            {
                Console.WriteLine(userInput+" - отсутствует в базе");
            }

            return IsPerson;
        }

        static bool IsPersonInDossier(string[] fullName, string[] positions, ref int numberPerson,string userInput)
        {
            bool IsPerson = false;
            int tempI = 0;

            for (int i = 0; i < fullName.Length; i++)
            {

                if (userInput == fullName[i].Split(' ')[0])
                {
                    IsPerson = true;
                    tempI = i;
                    numberPerson = i;
                }
            }

            if (IsPerson == true)
            {
                Console.WriteLine(fullName[tempI] + " - " + positions[tempI]);
            }
            else
            {
                Console.WriteLine(userInput + " - отсутствует в базе");
            }

            return IsPerson;
        }


        static string[] SaveArray(string[] array,int lengthArray, string stringText)
        {
            string[] temp = new string[lengthArray];

            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            temp[temp.Length - 1] = stringText;

            return temp;
        }

        static string[] SaveArray(string[] array, int lengthArray,  int userInput)
        {
            string[] temp = new string[lengthArray];
            int counterTemp = 0;

            for (int i = 0; i < array.Length; i++)
            {

               if(userInput!=i)
                {
                    temp[counterTemp] = array[i];
                    counterTemp++;
                }
            }
            return temp;
        }
    }
}
