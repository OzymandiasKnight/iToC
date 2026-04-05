using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;

namespace Archivum
{
	public class ProjectInfos
	{
		public string name = "";
		public string codeLine = "";
		public int width = 128;
		public int height = 128;
		public string xLine = "X";
		public string yLine = "Y";
		public List<Vector> pixels = new List<Vector>();
	}

	public static class Utilitary
	{
		public static string getEnvPath() {
			return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		}
		public static string getAppPath() {
			return Path.Combine(getEnvPath(), "iToc");

		}
	
		public static string getData(string data, string id) {
			string result = "";
			foreach(string line in data.Split("\n")) {
				if (line.StartsWith("<"+id+">") && line.EndsWith("</"+id+">")) {
					int end = line.Length-(id.Length+2+id.Length+3);
					result = line.Substring(id.Length+2, end);
					return result;
				}
			}
			return result;
		}

		public static ProjectInfos loadProject(string name) {
			ProjectInfos project = new ProjectInfos();
			string file_name = name+".txt";
			string path = Path.Combine(getAppPath(), file_name);
			string data = "";
			try {
				data = File.ReadAllText(path);
				project.name = getData(data, "title");
				project.codeLine = getData(data, "codeline");
				project.height = Int32.Parse(getData(data, "height"));
				project.width = Int32.Parse(getData(data, "width"));
				project.xLine = getData(data, "xline");
				project.yLine = getData(data, "yline");
				string[] pixels = getData(data, "pixels").Split(",");
				if (pixels.Length > 1) {
					for (int x=0; x<pixels.Length; x++) {
						if (pixels[x].Contains(":")) {
							string[] values = pixels[x].Split(":");
							project.pixels.Add(new Vector(Int32.Parse(values[0]), Int32.Parse(values[1])));
						}
					}
				}
			}
			catch (FileNotFoundException) {
				return project;
			}
			return project;
		}

		public static void saveProject(ProjectInfos infos)
		{
			string data = "";
			data += "<title>"+infos.name+"</title>\n";
			data += "<width>"+infos.width+"</width>\n";
			data += "<height>"+infos.height+"</height>\n";
			data += "<codeline>"+infos.codeLine+"</codeline>\n";
			data += "<xline>"+infos.xLine+"</xline>\n";
			data += "<yline>"+infos.yLine+"</yline>\n";
			data += "<pixels>";
			for (int x=0; x<infos.pixels.Count; x++) {
				data += infos.pixels[x].X + ":" + infos.pixels[x].Y + (x>=infos.pixels.Count-1?"":",");
			}
			data += "</pixels>";
			string file_name = infos.name+".txt";
			string path = Path.Combine(getAppPath(), file_name);
			File.WriteAllText(path, data);
		}

	}
}
