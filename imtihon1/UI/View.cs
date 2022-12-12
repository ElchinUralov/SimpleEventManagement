namespace imtihon1.UI
{
    public class View
    {
        public void MainMenu()
        {
            Console.WriteLine("1.Ro'yxatdan o'tish");
            Console.WriteLine("2.Tizimga kirish");
            Console.WriteLine();
            Console.Write("--> ");
            int change = int.Parse(Console.ReadLine()!);

            switch (change)
            {
                case 1:
                    {

                    } break;
                case 2:
                    {

                    } break;

                default:
                    MainMenu();
                    break;
            }
        }
    }
}
