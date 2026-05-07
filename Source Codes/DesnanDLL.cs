using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Reflection;
namespace nvgfileint
{
    public class Nvgfileint // desabreviado .nvg file interpreter
    {


        public void interpretar(string path)
        {
            if (Path.GetExtension(path).ToLower() != ".nvg")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error, this is not a nvg file,my english is so bad");
                Console.ResetColor();
                return;
            }
            string nvgArt = @"
 __   __     __   __     ______        __     __   __     ______      ______     ______   ______     ______     ______   ______     _____    
/\ ""-.\ \   /\ \ / /   /\  ___\      /\ \   /\ ""-.\ \   /\__  _\    /\  ___\   /\__  _\ /\  __ \   /\  == \   /\__  _\ /\  ___\   /\  __-.  
\ \ \-.  \  \ \ \'/    \ \ \__ \     \ \ \  \ \ \-.  \  \/_/\ \/    \ \___  \  \/_/\ \/ \ \  __ \  \ \  __<   \/_/\ \/ \ \  __\   \ \ \/\ \ 
 \ \_\\""_\  \ \__|     \ \_____\     \ \_\  \ \_\\""_\    \ \_\     \/\_____\    \ \_\  \ \_\ \_\  \ \_\ \_\    \ \_\  \ \_____\  \ \____- 
  \/_/ \/_/   \/_/       \/_____/      \/_/   \/_/ \/_/     \/_/      \/_____/     \/_/   \/_/\/_/   \/_/ /_/     \/_/   \/_____/   \/____/ 
";

            Console.WriteLine(nvgArt);
            bool readytoextract = false;
            string destino = @"C:\Novagia\Temp\Extractions\";
            string filename = null;
            if (File.Exists(path))
            {
                filename = Path.GetFileNameWithoutExtension(path);
                destino = Path.Combine(destino, filename);
                readytoextract = true;
            }
            if (!Directory.Exists(destino))
            {
                Directory.CreateDirectory(destino);
            }
            else
            {
                Directory.Delete(destino, true);
                string ascii = @"
  _  _____ _     _        ____ ___  __  __ ____  _     _____ _____ _____ ____  
 | |/ /_ _| |   | |      / ___/ _ \|  \/  |  _ \| |   | ____|_   _| ____|  _ \ 
 | ' / | || |   | |     | |  | | | | |\/| | |_) | |   |  _|   | | |  _| | | | |
 | . \ | || |___| |___  | |__| |_| | |  | |  __/| |___| |___  | | | |___| |_| |
 |_|\_\___|_____|_____|  \____\___/|_|  |_|_|   |_____|_____| |_| |_____|____/ 
                                                                                
                    ____  _   _  ____ ____ _____ ____ ____  
                   / ___|| | | |/ ___/ ___| ____/ ___/ ___| 
                   \___ \| | | | |  | |   |  _| \___ \___ \ 
                    ___) | |_| | |__| |___| |___ ___) |___) |
                   |____/ \___/ \____\____|_____|____/____/  
";

                Console.WriteLine(ascii);
                Directory.CreateDirectory(destino);


            }
            if (readytoextract == true)
            {
                // path é o caminho pro .nvg preciso renomear ele e mover pra novagia/temp/extractions/nome do arquivo
                // esse caminho é representado pela variavel destino
                // não,calma o problema não é aqui pq extraiu o app
                ZipFile.ExtractToDirectory(path, destino);
            }

            string maincspath = Path.Combine(destino, "main.cs");
            if (File.Exists(maincspath))
            {
                ProcessStartInfo compile = new ProcessStartInfo();
                string cscexepath = Path.Combine(Directory.GetCurrentDirectory(), "Dependencies", "Desnan", "csc.exe");
                compile.FileName = cscexepath;
                compile.Arguments = "/out:app.exe *.cs";
                compile.WorkingDirectory = destino;
                compile.UseShellExecute = false;
                Thread.Sleep(50);
                Process compiler = Process.Start(compile);
                compiler.WaitForExit();
                // provavel que o problema seja aqui pois ele cria o app , não roda ele então como posso rodar o .exe? já sei
                string exepath = Path.Combine(destino, "app.exe");
                if (File.Exists(exepath))
                {
                    ProcessStartInfo inforun = new ProcessStartInfo();
                    inforun.FileName = exepath;
                    inforun.UseShellExecute = false;
                    inforun.WorkingDirectory = destino;
                    Process.Start(inforun);
                }
            }
        }
    }
}
// 100 line code i like this shimmy shimmy yay shimmy yay