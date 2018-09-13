using CrashBandicoot.Models;
using CrashBandicoot.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrashBandicoot.Services
{
    public class AppState
    {
        public IReadOnlyList<SelectListItem> Platforms => _platforms;
        private readonly List<SelectListItem> _platforms = new List<SelectListItem>();

        public IReadOnlyList<SelectListItem> Games => _games;
        private readonly List<SelectListItem> _games = new List<SelectListItem>();
        
        public IReadOnlyList<SelectListItem> Levels => _levels;
        private readonly List<SelectListItem> _levels = new List<SelectListItem>();

        public IReadOnlyList<PlayerTime> LevelRankings => _levelRankings;
        private readonly List<PlayerTime> _levelRankings = new List<PlayerTime>();

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public SelectListItem SelectedPlatform { get; set; }
        
        public void ChangePlatform(SelectListItem selectedItem)
        {
            Console.WriteLine($"Current Selected Platform {SelectedPlatform.Key}");
            Console.WriteLine($"Changing to Selected Platform {selectedItem.Key}");
            SelectedPlatform = selectedItem;
            NotifyStateChanged();
        }

        public SelectListItem SelectedGame { get; set; }

        public void ChangeGame(SelectListItem selectedItem)
        {
            Console.WriteLine($"Current Selected Game {SelectedGame.Key}");
            Console.WriteLine($"Changing to Selected Game {selectedItem.Key}");
            SelectedGame = selectedItem;
            InitialiseLevels();
            NotifyStateChanged();
        }

        public SelectListItem SelectedLevel { get; set; }

        public void ChangeLevel(SelectListItem selectedItem)
        {
            Console.WriteLine($"Current Selected Level {SelectedLevel.Key}");
            Console.WriteLine($"Changing to Selected Level {selectedItem.Key}");

            SelectedLevel = selectedItem;
            NotifyStateChanged();
        }

        public AppState()
        {
            InitialisePlatforms();
            InitialiseGames();
            InitialiseLevels();
        }

        private void InitialisePlatforms()
        {
            _platforms.Add(new SelectListItem("all", "All"));
            _platforms.Add(new SelectListItem("psn", "Playstation 4"));
            _platforms.Add(new SelectListItem("xbl", "XBox One"));
            _platforms.Add(new SelectListItem("switch", "Ninendo Switch"));
            SelectedPlatform = _platforms.First();
        }

        private void InitialiseGames()
        {
            _games.Add(new SelectListItem("1", "Crash Bandicoot"));
            _games.Add(new SelectListItem("2", "Crash Bandicoot 2: Cortex Strikes Back"));
            _games.Add(new SelectListItem("3", "Crash Bandicoot 3: Warped"));
            SelectedGame = _games.First();
        }

        private void InitialiseLevels()
        {
            if (SelectedGame != null)
            {
                _levels.Clear();
            
                switch(SelectedGame.Key)
                {
                    case "1" :
                        _levels.AddRange(Crash1Levels);
                        break;
                    case "2" :
                        _levels.AddRange(Crash2Levels);
                        break;
                    case "3" :
                        _levels.AddRange(Crash3Levels);
                        break;
                }
            }
            else
            {
                _levels.Clear();
                _levels.AddRange(Crash1Levels);
            }
            SelectedLevel = _levels.First();
        }

        private IList<SelectListItem> Crash1Levels 
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem("1", "N Sanity Beach"),
                    new SelectListItem("2", "Jungle Rollers"),
                    new SelectListItem("3", "The Great Gate"),
                    new SelectListItem("4", "Boulders"),
                    new SelectListItem("5", "Upstream"),
                    new SelectListItem("6", "Rolling Stones"),
                    new SelectListItem("7", "Hog Wild"),
                    new SelectListItem("8", "Native Fortress"),
                    new SelectListItem("9", "Up the Creek"),
                    new SelectListItem("10", "The Lost City"),
                    new SelectListItem("11", "Temple Ruins"),
                    new SelectListItem("12", "Road to Nowhere"),
                    new SelectListItem("13", "Boulder Dash"),
                    new SelectListItem("14", "Whole Hog"),
                    new SelectListItem("15", "Sunset Vista"),
                    new SelectListItem("16", "Heavy Machinery"),
                    new SelectListItem("17", "Cortex Power"),
                    new SelectListItem("18", "Generator Room"),
                    new SelectListItem("19", "Toxic Waste"),
                    new SelectListItem("20", "The High Road"),
                    new SelectListItem("21", "Slippery Climb"),
                    new SelectListItem("22", "Lights Out"),
                    new SelectListItem("23", "Fumbling in the Dark"),
                    new SelectListItem("24", "Jaws of Darkness"),
                    new SelectListItem("25", "Castle Machinery"),
                    new SelectListItem("26", "The Lab"),
                    new SelectListItem("28", "Stormy Ascent")
                };
            }
        }
        private IList<SelectListItem> Crash2Levels 
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem("1", "Turtle Woods"),
                    new SelectListItem("2", "Snow Go"),
                    new SelectListItem("3", "Hang Eight"),
                    new SelectListItem("4", "The Pits"),
                    new SelectListItem("5", "Crash Dash"),
                    new SelectListItem("6", "Snow Biz"),
                    new SelectListItem("7", "Air Crash"),
                    new SelectListItem("8", "Bear It"),
                    new SelectListItem("9", "Crash Crush"),
                    new SelectListItem("10", "The Eel Deal"),
                    new SelectListItem("11", "Plant Food"),
                    new SelectListItem("12", "Sewer or Later"),
                    new SelectListItem("13", "Bear Down"),
                    new SelectListItem("14", "Road to Ruin"),
                    new SelectListItem("15", "Un-Bearable"),
                    new SelectListItem("16", "Hangin' Out"),
                    new SelectListItem("17", "Diggin' It"),
                    new SelectListItem("18", "Cold Hard Crash"),
                    new SelectListItem("19", "Ruination"),
                    new SelectListItem("20", "Bee-Having"),
                    new SelectListItem("21", "Piston It Away"),
                    new SelectListItem("22", "Rock It"),
                    new SelectListItem("23", "Night Fight"),
                    new SelectListItem("24", "Pack Attack"),
                    new SelectListItem("25", "Spaced Out"),
                    new SelectListItem("26", "Totally Bear"),
                    new SelectListItem("27", "Totally Fly")                    
                };
            }
        }
        private IList<SelectListItem> Crash3Levels 
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem("1", "Toad Village"),
                    new SelectListItem("2", "Under Pressure"),
                    new SelectListItem("3", "Orient Express"),
                    new SelectListItem("4", "Bone Yard"),
                    new SelectListItem("5", "Makin' Waves"),
                    new SelectListItem("6", "Gee Wiz"),
                    new SelectListItem("7", "Hang 'Em High"),
                    new SelectListItem("8", "Hog Ride"),
                    new SelectListItem("9", "Tomb Time"),
                    new SelectListItem("10", "Midnight Run"),
                    new SelectListItem("11", "Dino Might"),
                    new SelectListItem("12", "Deep Trouble"),
                    new SelectListItem("13", "High Time"),
                    new SelectListItem("14", "Road Crash"),
                    new SelectListItem("15", "Double Header"),
                    new SelectListItem("16", "Sphynxinator"),
                    new SelectListItem("17", "Bye Bye Blimps"),
                    new SelectListItem("18", "Tell No Tales"),
                    new SelectListItem("19", "Future Frenzy"),
                    new SelectListItem("20", "Tomb Wader"),
                    new SelectListItem("21", "Gone Tomorrow"),
                    new SelectListItem("22", "Orange Asphalt"),
                    new SelectListItem("23", "Flaming Passion"),
                    new SelectListItem("24", "Mad Bombers"),
                    new SelectListItem("25", "Bug Lite"),
                    new SelectListItem("26", "Ski Crazed"),
                    new SelectListItem("28", "Area 51"),
                    new SelectListItem("30", "Rings of Power"),
                    new SelectListItem("31", "Hot Coco"),
                    new SelectListItem("32", "Eggipus Rex")
                };
            }
        }
    }
}