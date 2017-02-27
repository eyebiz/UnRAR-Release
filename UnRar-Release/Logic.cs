﻿using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Readers;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace UnRAR_Release
{
    class Logic
    {
        public class ReleaseInfo
        {
            public RarArchive Archive { get; set; }
            public RarArchive SubsArchive { get; set; }
            public string Name { get; set; }
            public string ShowName { get; set; }
            public string Path { get; set; }
            public string Type { get; set; }
            public string CompressedSize { get; set; }
            public string UncompressedSize { get; set; }
            public string CompressionRatio { get; set; }
            public int NumberOfArchiveParts { get; set; }
            public int NumberOfFilesInArchive { get; set; }
            public bool SolidArchive { get; set; }
            public bool SubsPresent { get; set; }
        }

        public ReleaseInfo processRelease(string releasePath) {

            ReleaseInfo ri = new ReleaseInfo();
            ri.Path = releasePath;
            string[] rar, rarSubs;
            rar = Directory.GetFiles(ri.Path, "*.rar");

            if (rar.Length > 0)
            {
                string subsFolder = ri.Path + @"\" + "Subs";
                if (Directory.Exists(subsFolder))
                {
                    rarSubs = Directory.GetFiles(subsFolder, "*.rar");
                    ri.SubsArchive = RarArchive.Open(@rarSubs[0]);
                    ri.SubsPresent = true;
                }

                ri.Name = Path.GetFileName(Path.GetDirectoryName(rar[0]));

                Match match = Regex.Match(ri.Name, "S..E..");
                if (match.Success)
                {
                    ri.Type = "tv";
                    ri.SubsPresent = false;
                    ri.ShowName = ri.Name.Substring(0, (match.Index - 1));
                    ri.ShowName = ri.ShowName.Replace(".", " ");

                    // Exceptions
                    switch (ri.ShowName)
                    {
                        case "Marvels Agents of S H I E L D":
                            ri.ShowName = "Marvels Agents of SHIELD";
                            break;
                        case "Taboo UK":
                            ri.ShowName = "Taboo (2017)";
                            break;
                    }
                }
                else
                {
                    ri.Type = "movie";
                }
                ri.Archive = RarArchive.Open(@rar[0]);
                ri.CompressedSize = ri.Archive.TotalSize.ToString() + " Bytes = " + FormatBytes(ri.Archive.TotalSize);
                ri.UncompressedSize = ri.Archive.TotalUncompressSize.ToString() + " Bytes = " + FormatBytes(ri.Archive.TotalUncompressSize);
                ri.CompressionRatio = ((int)(0.5f + ((100f * ri.Archive.TotalSize) / ri.Archive.TotalUncompressSize))).ToString() + " %";
                ri.NumberOfArchiveParts = ri.Archive.Volumes.Count;
                ri.NumberOfFilesInArchive = ri.Archive.Entries.Count;
                ri.SolidArchive = ri.Archive.IsSolid;
            }
            return ri;
        }

        public void extractRelease(ReleaseInfo ri, string outputDir, Form1 sender)
        {
            if (!String.IsNullOrEmpty(ri.Name) && ri.NumberOfFilesInArchive > 0)
            {
                try
                {
                    // For TV episodes
                    if (ri.Type == "tv")
                    {
                        Directory.CreateDirectory(outputDir);
                        Thread backgroundThread = new Thread(() => sender.extractArchive(ri.Archive, outputDir));
                        backgroundThread.Start();
                    }
                    else
                    {
                        // For movies
                        string[] nfo = Directory.GetFiles(ri.Path, "*.nfo");
                        string outputReleaseDir = outputDir + @"\" + ri.Name;
                        Directory.CreateDirectory(outputReleaseDir);
                        processFile(nfo[0], outputReleaseDir, false);

                        Thread backgroundThread = new Thread(() => sender.extractArchive(ri.Archive, outputReleaseDir));
                        backgroundThread.Start();

                        if (ri.SubsPresent)
                        {
                            extractSubs(ri, outputReleaseDir);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Extract Error: " + ex.Message);
                }
            }
        }

        /*
        public void extractArchive(RarArchive archive, string outputDir, Form1 sender)
        {
            sender.setStatus("Extracting...", true);
            using (archive)
            {
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        entry.WriteToDirectory(outputDir, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
                sender.setStatus("Idle.", false);
            }
        }
        */

        public void extractArchiveSingleThread(RarArchive archive, string outputDir)
        {
            using (archive)
            {
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        entry.WriteToDirectory(@outputDir, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
            }
        }

        public void extractSubs(ReleaseInfo ri, string outputDir)
        {
            try
            {
                string outputSubsDir = outputDir + @"\" + "Subs";
                Directory.CreateDirectory(outputSubsDir);
                extractArchiveSingleThread(ri.SubsArchive, outputSubsDir);

                string[] rarSubs2 = Directory.GetFiles(outputSubsDir, "*.rar");
                if (rarSubs2.Length > 0)
                {
                    RarArchive archive = RarArchive.Open(@rarSubs2[0]);
                    extractArchiveSingleThread(archive, outputSubsDir);
                    File.SetAttributes(rarSubs2[0], FileAttributes.Normal);
                    File.Delete(rarSubs2[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Subs Error: " + ex.Message);
            }
        }

        public void processFile(string inputFileName, string outputDir, bool deleteInputFile)
        {
            try
            {
                string[] lines = File.ReadAllLines(inputFileName, Encoding.GetEncoding(28591));
                if (deleteInputFile)
                {
                    File.SetAttributes(inputFileName, FileAttributes.Normal);
                    File.Delete(inputFileName);
                }
                string fileOutput = outputDir + @"\" + Path.GetFileName(inputFileName);
                File.WriteAllLines(fileOutput, lines, Encoding.GetEncoding(28591));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        public void CreateAppConfig()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sb.AppendLine("<configuration>");
            sb.AppendLine("  <startup>");
            sb.AppendLine("    <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5.2\" />");
            sb.AppendLine("  </startup>");
            sb.AppendLine("  <appSettings>");
            sb.AppendLine("    <add key=\"ReleaseStartDir\" value=\"D:\\Torrents\" />");
            sb.AppendLine("    <add key=\"OutputDir\" value=\"X:\\HD\" />");
            sb.AppendLine("    <add key=\"TVDir\" value=\"D:\\TV\" />");
            sb.AppendLine("  </appSettings>");
            sb.AppendLine("</configuration>");
            File.WriteAllText(String.Concat(Application.ExecutablePath, ".config"), sb.ToString());
        }

        /*
        private void unix2dos(string unixfile, string dosfile)
        {
            string[] lines = File.ReadAllLines(unixfile);
            List<string> list_of_string = new List<string>();
            foreach (string line in lines)
            {
                list_of_string.Add(line.Replace("\n", "\r\n"));
            }
            File.WriteAllLines(dosfile, list_of_string);
        }
        */

    }
}