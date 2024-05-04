using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestFileManager
{
    [Theory]
    [InlineData("connect C:/home/pavel/ -m local")]
    public void TestConnectParser(string line)
    {
        var parser = new ConnectParser(new FileSystemFabric(new Collection<IFileSystem>() { new LocalFileSystem() }));
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(ConnectCommand), command?.GetType());
    }

    [Theory]
    [InlineData("tree list -d 2")]
    [InlineData("tree list")]
    public void TestTreeListParser(string line)
    {
        var parser = new TreeListParser();
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        context.TreeGoto("C:/home/pavel/");
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(TreeListCommand), command?.GetType());
    }

    [Theory]
    [InlineData("tree goto C:/home/pavel/")]
    public void TestTreeGotoParser(string line)
    {
        var parser = new TreeGotoParser();
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(TreeGotoCommand), command?.GetType());
    }

    [Theory]
    [InlineData("file move C:/home/pavel/1 C:/home/pavel/2")]
    public void TestFileMoveParser(string line)
    {
        var parser = new FileMoveParser();
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(FileMoveCommand), command?.GetType());
    }

    [Theory]
    [InlineData("file show C:/home/pavel/1.txt -m console")]
    public void TestFileShowParser(string line)
    {
        var parser = new FileShowParser();
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(FileShowCommand), command?.GetType());
    }

    [Theory]
    [InlineData("file copy C:/home/pavel/1.txt C:/home/pavel/2")]
    public void TestFileCopyParser(string line)
    {
        var parser = new FileCopyParser();
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(FileCopyCommand), command?.GetType());
    }

    [Theory]
    [InlineData("file delete C:/home/pavel/1.txt")]
    public void TestFileDeleteParser(string line)
    {
        var parser = new FileDeleteParser();
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(FileDeleteCommand), command?.GetType());
    }

    [Theory]
    [InlineData("disconnect")]
    public void TestDisconnectParser(string line)
    {
        var parser = new DisconnectParser();
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(DisconnectCommand), command?.GetType());
    }

    [Theory]
    [InlineData("file rename C:/home/pavel/1.txt 2.txt")]
    public void TestFileRenameParser(string line)
    {
        var parser = new FileRenameParser();
        var context = new Context(new Writter(), new WriterTree("\uD83D\uDCC4", "\uD83D\uDCC1"));
        ICommandFileManager? command = parser.Parse(context, line);
        Assert.Equal(typeof(FileRenameCommand), command?.GetType());
    }
}