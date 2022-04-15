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
            OutputMesadge();

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
                         
                        SearchInDossier(fullName, positions);

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

            fullName = SaveArray(ref fullName, fullName.Length + increment, tempString);
            positions = SaveArray(ref positions, positions.Length + increment, position);

            DefaultMesadge(fullName, positions);

        }
        static void DefaultMesadge(string[] fullName,string[] positions)
        {
            Console.Clear();
            OutputMesadge();
            ShowDossier(fullName, positions);

        }
        static void OutputMesadge()
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
                    Console.WriteLine(i+" " + fullName[i] + " - " + positions[i]);
                }
                else
                {
                    Console.WriteLine("  " + fullName[i] + " - " + positions[i]);
                }
            }
        }
        static void DeleteDossier(ref string[]fullName,ref string[]positions)
        {
            Console.Write("Для удаления работника введите фамилию - ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            int increment = -1;
            char divider = ' ';

            fullName = SaveArray(ref fullName, fullName.Length + increment, userInput, divider);
            positions = SaveArray(ref fullName, positions.Length + increment, userInput, divider);

            DefaultMesadge(fullName, positions);
        }
        static void SearchInDossier(string[] fullName, string[] positions)
        {
            Console.Write("Для поиска работника введите фамилию - ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            for (int i = 0; i < fullName.Length; i++)
            {

                if (userInput == fullName[i].Split(' ')[0])
                {
                    Console.WriteLine(fullName[i] + " - " + positions[i]);
                }
            }
        }
        static string[] SaveArray(ref string[] array,int lengthArray, string stringText)
        {
            string[] temp = new string[lengthArray];

            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            temp[temp.Length - 1] = stringText;


            return temp;
        }
        static string[] SaveArray(ref string[] array, int lengthArray, string stringText, char divider =' ')
        {
            string[] temp = new string[lengthArray];

            int counterTemp = 0;

            for (int i = 0; i < array.Length; i++)
            {

                if (stringText != array[i].Split(divider)[0])
                {
                    temp[counterTemp] = array[i];
                    counterTemp++;
                }
            }


            return temp;
        }
    }
}
