namespace Patterns.Structural.Facade.DvdPlayer;

public class _Test
{
    
    [Fact]
    private void DVD_Player()
    {
        var dimmer = new Dimmer();
        var dvdPlayer = new DvdPlayer();
        var dvd = new Dvd("Gone with the Wind 2 : Electric Bugaloo");
        var homeTheater = new HomeTheatre(dimmer, dvd, dvdPlayer);

        homeTheater.WatchMovie();
        Console.WriteLine();
        homeTheater.Pause();
        Console.WriteLine();
        homeTheater.Resume();
        Console.WriteLine();
        homeTheater.Pause();
    }

}