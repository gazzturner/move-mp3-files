using System;
using System.IO;

namespace MoveMP3Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = @"C:\Users\GarryTurner\Pictures\Game Covers";
            var files = Directory.GetFiles(directoryPath);
            
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                
               
                var guid = Guid.NewGuid().ToString();
                var name = guid + fi.Extension;

                var destinationPath = directoryPath + @"\renamed\" + name;
                

                //var tagFile = TagLib.File.Create(fi.FullName);
                //var artist = tagFile.Tag.FirstArtist;

                //if(string.IsNullOrWhiteSpace(artist))
                //    continue;

                //var album = tagFile.Tag.Album;

                //if (string.IsNullOrWhiteSpace(album))
                //    continue;

                //album = TidyName(album);

                //var title = tagFile.Tag.Title;
                //title = TidyName(title);

                //var artistPath = $"F:\\Music\\{artist}";
                //CreateArtistFolder(artistPath);

                //var albumPath = $"F:\\Music\\{artist}\\{album}";
                //CreateAlbumFolder(albumPath);

                //var destinationPath = albumPath + "\\" + fi.Name ;

                //if (FileAlreadyExists(destinationPath)) continue;

                MoveFile(file, destinationPath, fi.Name);
            }

            Console.WriteLine("MOVE COMPLETE");
            Console.ReadLine();
        }

        private static bool FileAlreadyExists(string destinationPath)
        {
            if (File.Exists(destinationPath))
            {
                Console.WriteLine($"{destinationPath} already exists");
                Console.WriteLine($"---------------------------------------");
                return true;
            }

            return false;
        }

        private static void MoveFile(string file, string destinationPath, string title)
        {
            File.Copy(file, destinationPath);
            //File.Delete(file);
            Console.WriteLine($"Moved {title} to {destinationPath}");
            Console.WriteLine($"---------------------------------------");
        }

        private static void CreateAlbumFolder(string albumPath)
        {
            if (Directory.Exists(albumPath)) 
                return;

            Directory.CreateDirectory(albumPath);
            Console.WriteLine($"Created {albumPath}");
        }

        private static void CreateArtistFolder(string artistPath)
        {
            if (Directory.Exists(artistPath)) 
                return;

            Directory.CreateDirectory(artistPath);
            Console.WriteLine($"Created {artistPath}");
        }

        private static string TidyName(string name)
        {
            if (name.Contains(":"))
            {
                name = name.Replace(":", "");
            }

            if (name.Contains("?"))
            {
                name = name.Replace("?", "");
            }

            if (name.Contains("\""))
            {
                name = name.Replace("\"", "");
            }

            return name;
        }
    }
}
