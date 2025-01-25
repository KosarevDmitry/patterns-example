using System.Net.Sockets;
using System.Text;


var repo= RepoRoot();
string src = Path.Combine(repo, "src");
//var exceptList = new List<string> { "bin", "obj", ".vs", ".idea"}.Select(x => Path.Combine(root, x)).ToArray();

string output = Path.Combine(repo, "output");
int rootLength = src.Length;
var dirs = GetRootDirs(src);

Provider(dirs);

void Provider(IEnumerable<string> dirs)
{
    foreach (var dir in dirs)
    {
        Bild(dir);
        var subdirs = Directory.EnumerateDirectories(dir);
        Provider(subdirs);
    }
}

void Bild(string dir)
{
    var files = Directory.EnumerateFiles(dir).ToArray();
    var bld = new StringBuilder();

    if (files.Length > 0)
    {
        foreach (var file in files)
        {
            string filecontent = File.ReadAllText(file);
            bld.AppendLine(filecontent);
            bld.AppendLine();
        }

        string filename = GetFileName(dir);
        string path = Path.Combine(output, filename + ".cs");
        
        File.WriteAllText(path, bld.ToString());
    }
}

string GetFileName(string dir) => dir.Substring(rootLength + 1).Replace(Path.DirectorySeparatorChar, '-');

//  root dir is where   `.git` dir os located
string RepoRoot()
{
    string dir = Directory.GetCurrentDirectory();
    
        while (true)
        {
            var marker = Directory.EnumerateDirectories(dir).Any(x => Path.GetFileName(x) == ".git");
            if (marker)
            {
                return dir;
            }

            dir = dir.Substring(0, dir.LastIndexOf(Path.DirectorySeparatorChar));
        }
    
}

IEnumerable<string> GetRootDirs(string root)
{
    string[] dirs = { "Behavioral", "Creational", "Structural" };
    foreach (var dir in dirs)
    {
        yield return Path.Combine(root, dir);
    }
}



