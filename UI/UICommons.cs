using System;
using System.Threading;

namespace tupacAlumnos;

public class UICommons
{
    public bool IsNightMode = false;

    public bool Toggle()
    {
        IsNightMode = !IsNightMode;
        ApplyTheme();
        return IsNightMode;
    }

    public void ApplyTheme()
    {
        if (IsNightMode)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        Console.Clear(); // Asegura que se aplique en toda la pantalla
    }

    private void SwitchColor(string color)
    {
        switch (color)
        {
            case "black":
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case "red":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "green":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "blue":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "cyan":
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case "gray":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
    }
    public void Header(string title)
    {
        DateTime today = DateTime.Today;
        DateTime hour = DateTime.Now;

        Console.ForegroundColor = IsNightMode ? ConsoleColor.DarkCyan : ConsoleColor.DarkYellow;
        Console.Clear();
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"▒▒  ▓▓▓▓▓ ▓▓ ▓▓ ▓▓▓▓   ▓▓▓   ▓▓▓               {today.ToString("dd/MM/yyyy"),50} ▒▒");
        Console.WriteLine($"▒▒░░░▓▓▓░░▓▓░▓▓░▓▓░▓▓░▓▓░▓▓░▓▓░▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒");
        Console.WriteLine($"▒▒   ▓▓▓  ▓▓ ▓▓ ▓▓▓▓  ▓▓▓▓▓ ▓▓                 {hour.ToString("hh:mm"),50} ▒▒");
        Console.WriteLine($"▒▒░░░▓▓▓░░▓▓░▓▓░▓▓░░░░▓▓░▓▓░▓▓░▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒");
        Console.WriteLine($"▒▒   ▓▓▓   ▓▓▓  ▓▓    ▓▓ ▓▓  ▓▓▓               {title.ToUpper(),50} ▒▒");
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"");
    }
    public void Menu1row2cols(string option1, string option2, string color1, string color2)
    {
        SwitchColor(color1);
        Console.Write("╔══════════════════════════════════════════════╗  ");
        SwitchColor(color2);
        Console.WriteLine($"  ╔══════════════════════════════════════════════╗");
        SwitchColor(color1);
        Console.Write($"║ {option1,44} ║  ");
        SwitchColor(color2);
        Console.WriteLine($"  ║ {option2,-44} ║");
        SwitchColor(color1);
        Console.Write("╚══════════════════════════════════════════════╝  ");
        SwitchColor(color2);
        Console.WriteLine($"  ╚══════════════════════════════════════════════╝");
        Console.WriteLine($"");

    }
    public void MenuOption(string option)
    {
        Console.ForegroundColor = IsNightMode ? ConsoleColor.Yellow : ConsoleColor.DarkBlue;
        Console.WriteLine($"╔══════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║ {option.ToUpper(),-90}   »»  ║");
        Console.WriteLine($"╚══════════════════════════════════════════════════════════════════════════════════════════════════╝");
    }
    public void TableHeader(string option1, string option2, string option3, string option4)
    {
        Console.ForegroundColor = IsNightMode ? ConsoleColor.DarkYellow : ConsoleColor.Blue;
        Console.WriteLine($"╔═══════╦══════════════════════════════════════════╦═════════════════════════╦═════════════════════╗");
        Console.WriteLine($"║ {option1.ToUpper(),-5} ║ {option2.ToUpper(),-39}  ║{option3.ToUpper(),-22}   ║{option4.ToUpper(),-21}║");
    }
    public void TableRow(string option1, string option2, string option3, string option4)
    {
        Console.ForegroundColor = IsNightMode ? ConsoleColor.Yellow : ConsoleColor.DarkBlue;
        Console.WriteLine($"╠───────┼──────────────────────────────────────────┼─────────────────────────┼─────────────────────╣");
        Console.WriteLine($"║ {option1.ToUpper(),-5} │ {option2.ToUpper(),-39}  │{option3.ToUpper(),-22}   │{option4.ToUpper(),-21}║");
    }
    public void TableEnd()
    {
        Console.ForegroundColor = IsNightMode ? ConsoleColor.Yellow : ConsoleColor.DarkBlue;
        Console.WriteLine($"╚═══════╩══════════════════════════════════════════╩═════════════════════════╩═════════════════════╝");
    }
    public void InputPlaceholder(string textInput)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"");
        Console.Write($"{textInput.ToUpper(),36}          »»»»»»»»          ");
    }
    public string InputText(string textInput)
    {
        Console.ForegroundColor = IsNightMode ? ConsoleColor.DarkCyan : ConsoleColor.DarkYellow;
        string text;
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.Write($"  {textInput.ToUpper(),-35} »»» ");
        text = Console.ReadLine();
        return text;
    }
    public void Message(bool success, string message)
    {
        Console.WriteLine($"");
        if (success)
        {
            Console.ForegroundColor = IsNightMode ? ConsoleColor.Green : ConsoleColor.DarkGreen;
        }
        else
        {
            Console.ForegroundColor = IsNightMode ? ConsoleColor.Red : ConsoleColor.DarkRed;

        }
        Console.WriteLine($"▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
        Console.WriteLine($"█■ {message.ToUpper(),-80}               ■█");
        Console.WriteLine($"▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");

        if (success)
        {
            PlaySuccess();
        }
        else
        {
            PlayError();
        }
        Console.ReadKey();
    }
    public void Alert(string message)
    {
        Console.ForegroundColor = IsNightMode ? ConsoleColor.DarkCyan : ConsoleColor.DarkYellow;
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.ForegroundColor = IsNightMode ? ConsoleColor.Magenta : ConsoleColor.DarkMagenta;
        Console.WriteLine($"  {message.ToUpper(),-80}                 ");
    }
    public void PlayIntro()
    {
        int[] notes = { 440, 440, 440, 349, 440, 440, 440, 349, 440, 440, 440, 349 };
        int duration = 200;

        if (OperatingSystem.IsWindows())
            foreach (var note in notes)
            {
                Console.Beep(note, duration);
                Thread.Sleep(30);
            }
        {

        }

    }
    public void PlayConfirmation()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(880, 150);
        }
    }
    public void PlaySuccess()
    {
        int[] notes = { 523, 659, 783 }; // C5, E5, G5
        int duration = 150;

        if (OperatingSystem.IsWindows())
        {
            foreach (var note in notes)
            {
                Console.Beep(note, duration);
            }
        }

    }
    public void PlayError()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(370, 400);
            Console.Beep(370, 400);
        }


    }
    public void IntroScreen()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        Console.WriteLine($"▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        Console.WriteLine($"▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ SISTEMA DE GESTIÓN ACADÉMICA ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
        Console.WriteLine($"░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
        Console.WriteLine($"░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"                                                                                                    ");
        Console.WriteLine($"                                                                                                    ");
        Console.WriteLine($"                                     ▓▓▓▓▓ ▓▓ ▓▓ ▓▓▓▓   ▓▓▓   ▓▓▓                                   ");
        Console.WriteLine($"                                      ▓▓▓  ▓▓ ▓▓ ▓▓ ▓▓ ▓▓ ▓▓ ▓▓ ▓▓                                  ");
        Console.WriteLine($"                                      ▓▓▓  ▓▓ ▓▓ ▓▓▓▓  ▓▓▓▓▓ ▓▓                                     ");
        Console.WriteLine($"                                      ▓▓▓  ▓▓ ▓▓ ▓▓    ▓▓ ▓▓ ▓▓ ▓▓                                  ");
        Console.WriteLine($"                                      ▓▓▓   ▓▓▓  ▓▓    ▓▓ ▓▓  ▓▓▓                                   ");
        Console.WriteLine($"                                                                                                    ");
        Console.WriteLine($"                                                                                                    ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
        Console.WriteLine($"░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
        Console.WriteLine($"░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒  CREADO POR ANDRÉS BIASUTTO  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine($"▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        Console.WriteLine($"▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        Console.WriteLine($"▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        PlayIntro();
        Console.ReadKey();
        Console.ResetColor();
    }
}
