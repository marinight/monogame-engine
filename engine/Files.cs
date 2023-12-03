using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine;

public class Files {
    static GraphicsDevice gd = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, new PresentationParameters());
    public static Texture2D GetTexture(string s) {
        FileStream fs = new FileStream(s, FileMode.Open);
        Texture2D tex = Texture2D.FromStream(gd, fs);
        fs.Dispose();
        return tex;
    }

    public static string GetText(string s) {
        StreamReader sr = new StreamReader(s);
        return sr.ReadToEnd();
    }

    public static void WriteText(string s, string c) {
        StreamWriter sw = new StreamWriter(s);
        sw.Write(c);
    }

    public static void AppendText(string s, string c) {
        StreamWriter sw = new StreamWriter(s);
        sw.Write(GetText(s) + c);
    }
}