namespace GutoBank
{
    public class Program
    {
        private static void menuPrincipal()
        {
            Console.WriteLine("Inserir novo usuario -----------------------(1)");
            Console.WriteLine("Deletar um usuario -------------------------(2)");
            Console.WriteLine("Listar todas as contas registradas ---------(3)");
            Console.WriteLine("Detalhes de um usuario ---------------------(4)");
            Console.WriteLine("Quantia armazenado no banco digite ---------(5)");
            Console.WriteLine("Manipular conta ----------------------------(6)");
            Console.WriteLine("Quantidade de usuarios no banco ------------(7)");
            Console.WriteLine("Sair do sistema ----------------------------(9)");
            Console.Write("Digite a opcao desejada : ");
        } // ok

        private static void menu()
        {
            Console.WriteLine("         Escolha uma das opcoes abaixo           ");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Para olhar seu saldo digite -------------------(1)");
            Console.WriteLine("Para realizar um saque digite -----------------(2)");
            Console.WriteLine("Para realizar uma transferencia digite --------(3)");
            Console.WriteLine("Para realizar um deposito digite --------------(4)");
            Console.WriteLine("Para simular investimentos digite -------------(5)");
            Console.WriteLine("Para Retornar ao menu principal ---------------(8)\n");
            return;
        }

        private static void opcaoInvalida()
        {
            Console.WriteLine("________________________________");
            Console.WriteLine("│Opcao invalida tente novamente│");
            Console.WriteLine("--------------------------------\n");
        }

        private static void retornoEncerrar()
        {
            Console.WriteLine("Para retornar para o menu do usuario digite ---(0)");
            Console.WriteLine("Para retornar para o menu principal -----------(8)\n");
        }

        private static void RegistrarNovoUsusario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o titular: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            Console.WriteLine();
            saldos.Add(0);
        } // ok

        private static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:F2}");
            }
        }     // listar contas ok

        public static void cpfNaoEncontrado()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("CPF nao encontrado na base de dados\n");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void nomeBanco()
        {
            Console.WriteLine(
             "\r\n|$$$$$$$$                                    /$$$$$$$" +
             "\r\n|$$$| |$$  |$$    $$| |$$$$$$$$| |$$$$$$$|   |$$__  $$                      |$$    /$$" +
             "\r\n|$$|       |$$    $$|    |$$|    |$$   $$|   |$$   \\$$   /$$$$$$  /$$$$$$$  |$$   /$$" +
             "\r\n|$$  ____  |$$    $$|    |$$|    |$$   $$|   |$$$$$$$    |____ $$ |$$__  $$ |$$  /$$/" +
             "\r\n|$$ |$$$$| |$$    $$|    |$$|    |$$   $$|   |$$__  $$   /$$$$$$$ |$$  \\ $$ |$$$$$$/" +
             "\r\n|$$  |$$$| |$$____$$|    |$$|    |$$   $$|   |$$   \\$$  /$$__  $$ |$$  | $$ |$$_  $$" +
             "\r\n|$$$$$$$$| |$$$$$$$$|    |$$|    |$$$$$$$|   |$$$$$$$/  |$$$$$$$$ |$$  | $$ |$$\\   $$" +
             "\r\n\\_______ /  \\______/     \\__/     \\_____/    |_______/   \\______/ |__/ |__/ |__/  \\__/");
        }

        private static void Main(string[] args)
        {
            double totalDeSaldos = 0;
            int opcaoPrincipal;
            int quantidade = 0;
            Console.ForegroundColor = ConsoleColor.Green;

            nomeBanco();
            Console.WriteLine();
            Console.WriteLine("Vamos configurar o sitema ");

            Console.Write("Digite a quantidade de usuarios : ");
            int quantidadeDeUsuarios = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Clear();

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<double> saldos = new List<double>();
            List<string> senhas = new List<string>();
            do
            {
                do
                {
                    do
                    {
                        menuPrincipal();
                        opcaoPrincipal = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Clear();
                        if (opcaoPrincipal < 0 || opcaoPrincipal > 9 || opcaoPrincipal == 8) { Console.WriteLine("Opcao invalida\n"); }
                    } while (opcaoPrincipal < 0 || opcaoPrincipal > 9 || opcaoPrincipal == 8);

                    if (opcaoPrincipal == 1)
                    {
                        for (int i = 0; i < quantidadeDeUsuarios; i++)
                        {
                            RegistrarNovoUsusario(cpfs, titulares, senhas, saldos);
                        }
                    }
                    if (opcaoPrincipal == 2)
                    {
                        Console.WriteLine("Qual o cpf do usuario que sera deletado ?");
                        string remove = Console.ReadLine();
                        int cpfARemover = cpfs.FindIndex(x => x == remove);

                        if (cpfARemover == -1)
                        {
                            cpfNaoEncontrado();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("CPF removido com sucesso\n");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                    if (opcaoPrincipal == 3)
                    {
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        Console.WriteLine();
                    }
                    if (opcaoPrincipal == 4)
                    {
                        Console.Write("Qual o CPF do usuario : ");
                        int cpf = cpfs.IndexOf(Console.ReadLine());

                        if (cpf == -1)
                        {
                            cpfNaoEncontrado();
                        }
                        else
                        {
                            Console.WriteLine($"CPF = {cpfs[cpf]} | Titular = {titulares[cpf]} | Saldo = R${saldos[cpf]:F2}");
                        }
                    }
                    if (opcaoPrincipal == 5)
                    {
                        for (int i = 0; i < cpfs.Count; i++)
                        {
                            totalDeSaldos = totalDeSaldos + saldos[i];
                        }
                        Console.WriteLine($"Quantia Armazenada no banco é R${totalDeSaldos}");
                        totalDeSaldos = 0;
                    }
                    if (opcaoPrincipal == 7)
                    {
                        for (int i = 0; i < cpfs.Count; i++)
                        {
                            quantidade++;
                        }
                        Console.WriteLine($"A quantidade armazenada no banco é de {quantidade} usuarios");
                        quantidade = 0;
                    }
                } while (opcaoPrincipal != 6 && opcaoPrincipal != 9);

                if (opcaoPrincipal == 9)
                { Console.WriteLine("Encerrando sistema ...."); }

                if (opcaoPrincipal == 6)
                {
                    double deposito = 0, transferencia = 0, saque = 0;
                    int opcao = 0;
                    Console.Write("Digite o CPF do usuario: ");
                    string cod = Console.ReadLine();
                    Console.Clear();

                    int result = cpfs.FindIndex(x => x == cod);

                    while (result == -1)
                    {
                        Console.WriteLine("\nCPF incorreta*");
                        cod = Console.ReadLine();
                        result = cpfs.FindIndex(x => x == cod);
                    }
                    if (result >= 0 && result < cpfs.Count)
                    {
                        Console.WriteLine("CPF aceito\n");
                        Console.WriteLine("Digite a senha ");
                        Console.Write("***");
                        string senhaInformada = Console.ReadLine();

                        if (senhas[result] == senhaInformada)
                        {
                            Console.WriteLine("Senha Aceita\n");
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("*******OLA SEJA BEM VINDO(A) AO GUTO BANK*********");
                            Console.WriteLine("-------------------------------------------------");
                            string nome = (titulares[result]);

                            do
                            {
                                menu();
                                opcao = int.Parse(Console.ReadLine());
                                Console.Clear();

                                if (opcao > 9 || opcao < 0)
                                {
                                    opcaoInvalida();
                                }
                            } while (opcao > 9 || opcao < 0);

                            do
                            {
                                if (opcao == 1)
                                {
                                    Console.WriteLine($"{titulares[result]} Seu saldo atual é R$ {saldos[result]}\n");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                else if (opcao == 2)
                                {
                                    Console.WriteLine($"{titulares[result]} Qual valor do saque ?");
                                    Console.Write("R$ ");
                                    saque = double.Parse(Console.ReadLine());
                                    saldos[result] -= saque;
                                    Console.WriteLine("Saque realizado com sucesso...");
                                    Console.WriteLine($"{titulares[result]} Saldo atual é R$ {saldos[result]}\n");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                else if (opcao == 3)
                                {
                                    Console.WriteLine("Digite o cpf para quem a transferencia sera enviada ?");
                                    Console.Write("CPF: ");
                                    string cpfTransferencia = Console.ReadLine();
                                    int transfer = cpfs.FindIndex(x => x == cpfTransferencia);

                                    while (transfer == -1 || cpfTransferencia == cpfs[result])
                                    {
                                        Console.WriteLine("Usuario invalido, Tente novamente");
                                        cpfTransferencia = Console.ReadLine();
                                        transfer = cpfs.FindIndex(x => x == cpfTransferencia);
                                    }

                                    Console.WriteLine($"{titulares[result]} Qual valor da tranferencia?");
                                    Console.Write("R$ ");
                                    transferencia = double.Parse(Console.ReadLine());
                                    Console.WriteLine($"Transferencia de {transferencia} para {titulares[transfer]} confirma ? (s) ou (n) ");
                                    string resposta = Console.ReadLine();
                                    Console.Clear();
                                    if (resposta == "s")
                                    {
                                        saldos[result] -= transferencia;
                                        saldos[transfer] += transferencia;
                                        Console.WriteLine("Transferencia realizada com sucesso");
                                        Console.WriteLine($"{titulares[result]} Saldo atual é R$ {saldos[result]}\n");
                                        retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Transferencia nao efetivada");
                                        Console.WriteLine($"Saldo atual é R$ {saldos[result]}\n");
                                        retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                        Console.Clear();
                                    }
                                }
                                else if (opcao == 4)
                                {
                                    Console.WriteLine($"{titulares[result]} Qual valor do deposito ?");
                                    Console.Write("R$ ");
                                    deposito = double.Parse(Console.ReadLine());
                                    saldos[result] += deposito;
                                    Console.WriteLine($"{titulares[result]} Saldo atual é R$ {saldos[result]}\n");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                else if (opcao == 5)
                                {
                                    Console.Write("Quanto gostaria de investir ?\nR$: ");
                                    int valorInvestido = int.Parse(Console.ReadLine());
                                    Console.Write("Quanto tempo seu dinheiro ficara investido ?\nMeses: ");
                                    int tempoInvestido = int.Parse(Console.ReadLine());
                                    Console.WriteLine("");

                                    double poupanca = valorInvestido * 0.005 * tempoInvestido;
                                    double rendaVariavel = valorInvestido * 0.01 * tempoInvestido;
                                    double fundosImobiliarios = valorInvestido * 0.015 * tempoInvestido;
                                    Console.WriteLine($"{titulares[result]} se investido em poupanca o retorno sera de R$ {poupanca} = Totalizando R$ {valorInvestido + poupanca}...");
                                    Console.WriteLine($"Se investido em renda variavel o retorno sera de R$ {rendaVariavel} = Totalizando R$ {valorInvestido + rendaVariavel}...");
                                    Console.WriteLine($"Se investido em fundos imobiliarios o retorno sera de R$ {fundosImobiliarios} = Totalizando  R$ {valorInvestido + fundosImobiliarios}...\n -----------------------------------");
                                    retornoEncerrar(); opcao = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                }

                                if (opcao == 0)
                                {
                                    do
                                    {
                                        menu(); opcao = int.Parse(Console.ReadLine());
                                        if (opcao > 9 || opcao < 0)
                                        {
                                            opcaoInvalida();
                                        }
                                    } while (opcao > 9 || opcao < 0);
                                }
                                else if (opcao < 0 || opcao > 9)
                                {
                                    do
                                    {
                                        menu(); opcao = int.Parse(Console.ReadLine());
                                        if (opcao > 9 || opcao < 0)
                                        {
                                            opcaoInvalida();
                                        }
                                    } while (opcao < 0 || opcao > 9);
                                }
                            } while (opcao != 8);
                        }
                    }
                }
            } while (opcaoPrincipal != 9);
        }
    }
}