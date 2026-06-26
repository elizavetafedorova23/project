using System;
using System.Threading;

class DownloadSimulator
{
    public event Action<int> ProgressChanged;

    public void Download()
    {
        int progress = 0;

        while (progress <= 100)
        {
            ProgressChanged?.Invoke(progress);
            Thread.Sleep(250);
            progress += 10;
        }
    }
}

class Program
{
    static void ShowProgress(int value)
    {
        Console.WriteLine(value + "%");
    }

    static void Main()
    {
        DownloadSimulator d = new DownloadSimulator();

        d.ProgressChanged += ShowProgress;

        d.Download();

        Console.WriteLine("Готово");
    }
}
