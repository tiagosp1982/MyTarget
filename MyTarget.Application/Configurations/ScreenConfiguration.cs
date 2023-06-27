using MyTarget.Application.Entities;
using MyTarget.Domain.Entities;

namespace MyTarget.Application.Configurations
{
    public abstract class ScreenConfiguration
    {
        public void Header()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("###############################################################################", Console.ForegroundColor);
            Console.WriteLine("");
            Console.WriteLine("                      W E L C O M E   T O   T A R G E T                        ", Console.ForegroundColor);
            Console.WriteLine("");
            Console.WriteLine("###############################################################################", Console.ForegroundColor);
            Console.WriteLine("");
            Console.WriteLine("");
        }
        public Int32 InfoType()
        {
            bool caracter = false;
            int value;
            string opcao = String.Empty;

            this.Header();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Selecione o tipo de jogo.");
            Console.WriteLine("1-Lotofácil;");
            Console.WriteLine("");

            do
            {
                Console.Write("Informe o tipo de jogo e pressione <ENTER>: ");
                opcao = Console.ReadLine();

                if (!int.TryParse(opcao, out value)) // Try to parse the string as an integer
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! A   o p ç ã o   d e v e   s e r   n u m é r i c a.", Console.ForegroundColor);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (int.Parse(opcao) != 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! A   o p ç ã o   i n f o r m a d a   n ã o   e x i s t e.", Console.ForegroundColor);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else { caracter = true; }
            } while (!caracter);
            Console.WriteLine("");

            return Convert.ToInt32(opcao);
        }
        public Int16 FilterType()
        {
            bool caracter = false;
            int value;
            string opcao = String.Empty;

            this.Header();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Selecione o intervalo para análise.");
            Console.WriteLine("1-Todos os Concursos;");
            Console.WriteLine("2-Intervalo de Concurso;");
            Console.WriteLine("");

            do
            {
                Console.Write("Informe a opção desejada e pressione <ENTER>: ");
                opcao = Console.ReadLine();

                if (!int.TryParse(opcao, out value)) // Try to parse the string as an integer
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! A   o p ç ã o   d e v e   s e r   n u m é r i c a.", Console.ForegroundColor);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if ((int.Parse(opcao) != 1) && (int.Parse(opcao) != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! A   o p ç ã o   i n f o r m a d a   n ã o   e x i s t e.", Console.ForegroundColor);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else { caracter = true; }
            } while (!caracter);
            Console.WriteLine("");

            return Convert.ToInt16(opcao);
        }
        public Int16 AnalysisOption()
        {
            bool caracter = false;
            int value;
            string opcao = String.Empty;

            this.Header();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Selecione a análise desejada.");
            Console.WriteLine("1-Tendência por dezena;");
            Console.WriteLine("2-Tendência com peso de frequência por dezena;");
            Console.WriteLine("3-Frequência média de repetições por dezena;");
            Console.WriteLine("4-Total de sorteios por dezena;");
            Console.WriteLine("5-Conferir resultados anteriores;");
            //Console.WriteLine("4-Maior intervalo de ausência por dezena;");
            //Console.WriteLine("5-Estudo de probabilidade para próximo concurso;");
            Console.WriteLine("");

            do
            {
                Console.Write("Informe a opção desejada e pressione <ENTER>: ");
                opcao = Console.ReadLine();

                if (!int.TryParse(opcao, out value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! A   o p ç ã o   d e v e   s e r   n u m é r i c a.", Console.ForegroundColor);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (int.Parse(opcao) != 1 &&
                         int.Parse(opcao) != 2 &&
                         int.Parse(opcao) != 3 &&
                         int.Parse(opcao) != 4 &&
                         int.Parse(opcao) != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! A   o p ç ã o   i n f o r m a d a   n ã o   e x i s t e.", Console.ForegroundColor);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else { caracter = true; }
            } while (!caracter);
            Console.WriteLine("");

            return Convert.ToInt16(opcao);
        }
        public void DataNotFound()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Desculpe! Não foi possível carregar os dados necessários.");
            Console.WriteLine("");
        }
        public string InformBet(List<int> possibilityHit)
        {
            this.Header();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Quantidade mínima de dezenas: " + possibilityHit[0].ToString());
            Console.WriteLine("Quantidade máxima de dezenas: " + possibilityHit[1].ToString());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Informe o jogo ## SEPARADO POR VÍRGULA (,): ");
            

            return "";
        }
        public ContestBreakEntity RangeFilter(List<ResultDrawEntity> results)
        {
            bool caracter = false;
            int value;
            string opcao = String.Empty;
            ContestBreakEntity obj = new ContestBreakEntity();

            this.Header();

            obj.informedContests = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            do
            {
                Console.Write("Informe o concurso inicial e pressione <ENTER>: ");
                opcao = Console.ReadLine();

                if (!int.TryParse(opcao, out value)) // Try to parse the string as an integer
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! A   o p ç ã o   d e v e   s e r   n u m é r i c a.", Console.ForegroundColor);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    var find = results.Find(x => x.contestNumber == int.Parse(opcao));
                    if (find != null)
                    {
                        caracter = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! O  c o n c u r s o   i n f o r m a d o   n ã o   e x i s t e.", Console.ForegroundColor);
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
            } while (!caracter);
            Console.WriteLine("");
            obj.initialContest = Convert.ToInt16(opcao);

            Console.ForegroundColor = ConsoleColor.Yellow;
            do
            {
                caracter = false;
                Console.Write("Informe o concurso final e pressione <ENTER>: ");
                opcao = Console.ReadLine();

                if (!int.TryParse(opcao, out value)) // Try to parse the string as an integer
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! A   o p ç ã o   d e v e   s e r   n u m é r i c a.", Console.ForegroundColor);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    var find = results.Find(x => x.contestNumber == int.Parse(opcao));
                    if (find != null)
                    {
                        caracter = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("O P Ç Ã O   I N V A L I D A!!! O  c o n c u r s o   i n f o r m a d o   n ã o   e x i s t e.", Console.ForegroundColor);
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
            } while (!caracter);
            obj.finalContest = Convert.ToInt16(opcao);
            Console.WriteLine("");

            if (obj.initialContest > obj.finalContest)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("O concurso inicial não pode ser maior do que o concurso final", Console.ForegroundColor);
                Console.WriteLine("");
                RangeFilter(results);
            }
            obj.informedContests = true;

            return obj;
        }
        public void FinalizeProcess()
        {
            this.Header();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!A R Q U I V O   G E R A D O   C O M   S U C E S S O!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("");
            Console.WriteLine("Verifique o arquivo gerado na pasta ANALISES");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("PRESSIONE QUALQUER TECLA PARA CONTINUAR...");
            Console.ReadKey();
        }
    }
}
