using System.Diagnostics;

var solution = new Solutions.Solution();

var stdin = Console.In;
var stdout = Console.Out;

var inputStream = new MemoryStream();
var outputStream = new MemoryStream();

var input = File.ReadAllText("input") + Environment.NewLine;
var answer = File.ReadAllText("answer") + Environment.NewLine;

var inputWriter = new StreamWriter(inputStream);
inputWriter.WriteLine(input);
inputWriter.Flush();

inputStream.Seek(0, SeekOrigin.Begin);

var newIn = new StreamReader(inputStream);
var newOut = new StreamWriter(outputStream);
Console.SetIn(newIn);
Console.SetOut(newOut);

var sw = new Stopwatch();
sw.Start();
solution.Main();

newOut.Flush();
outputStream.Seek(0, SeekOrigin.Begin);
sw.Stop();

var outputReader = new StreamReader(outputStream);
var result = outputReader.ReadToEnd();

newIn.Close();
newOut.Close();
inputStream.Close();
outputStream.Close();

Console.SetIn(stdin);
Console.SetOut(stdout);

Console.WriteLine(result == answer ? "맞혔습니다." : "틀렸습니다.");
Console.WriteLine($"Elapsed {sw.ElapsedMilliseconds}ms");
Console.WriteLine();
Console.WriteLine("=== 제출한 답 ===");
Console.WriteLine(result);
Console.WriteLine("=== 정답 ===");
Console.WriteLine(answer);