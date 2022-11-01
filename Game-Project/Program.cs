using Library.Serializers;
using System;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        using var app = new Application.App();
        app.Run();
    }
}

