using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2024.Days
{
    internal class Day6
    {
        internal class Space
        {
            public enum SpaceType
            {
                Empty,
                Obstruction,
            }
            public SpaceType Type { get; set; }
            public bool Visited { get; set; }
            public int XCoord { get; set; }
            public int YCoord { get; set; }
        }

        internal class Dude
        {
            public enum Direction
            {
                West,
                North,
                East,
                South,
            }
            public Direction Heading { get; set; }
            public int XCoord { get; set; }
            public int YCoord { get; set; }

            public void Rotate()
            {
                switch (Heading)
                {
                    case Direction.West:
                        Heading = Direction.North;
                        break;
                    case Direction.North:
                        Heading = Direction.East;
                        break;
                    case Direction.East:
                        Heading = Direction.South;
                        break;
                    case Direction.South:
                        Heading = Direction.West;
                        break;
                    default:
                        break;
                }
            }
        }

        private static Tuple<Dude, List<List<Space>>> CreateBoard()
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Inputs", "day6.input"));

            var map = new List<List<Space>>();
            var guy = new Dude();
            for (int i = 0; i < lines.Length; i++)
            {
                var row = new List<Space>();
                for (int j = 0; j < lines[i].Length; j++)
                {
                    switch (lines[i][j])
                    {
                        case '.':
                            row.Add(new()
                            {
                                Type = Space.SpaceType.Empty,
                                Visited = false,
                                XCoord = j,
                                YCoord = i,
                            });
                            break;
                        case '#':
                            row.Add(new()
                            {
                                Type = Space.SpaceType.Obstruction,
                                Visited = false,
                                XCoord = j,
                                YCoord = i,
                            });
                            break;
                        case '^':
                            var space = new Space()
                            {
                                Type = Space.SpaceType.Empty,
                                Visited = true,
                                XCoord = j,
                                YCoord = i,
                            };

                            row.Add(space);
                            guy.XCoord = j;
                            guy.YCoord = i;
                            guy.Heading = Dude.Direction.North;
                            break;
                        default:
                            break;
                    }
                }
                map.Add(row);
            }
            return new Tuple<Dude, List<List<Space>>>(guy, map);
        }

        public static void Day6P2()
        {
            var board = CreateBoard();
            var guy = board.Item1;
            var map = board.Item2;

            //traverse once to see which positions might need to change
            var keepMoving = true;
            while (keepMoving)
            {
                keepMoving = Traverse(guy, map);
            }
            var spacesThatMatter = new List<Space>();
            foreach (var row in map)
            {
                spacesThatMatter.AddRange(row.Where(x => x.Visited));
            }

            var cyclesCount = 0;
            //change each empty space to an obstacle and see if it creates a cycle
            foreach (var spaceThatMatters in spacesThatMatter)
            {
                var newBoard = CreateBoard();
                guy = newBoard.Item1;
                var modifiedMap = newBoard.Item2;

                var rowIndex = spaceThatMatters.YCoord;
                var columnIndex = spaceThatMatters.XCoord;

                if (modifiedMap[rowIndex][columnIndex].Type == Space.SpaceType.Obstruction ||
                    (rowIndex == guy.YCoord && columnIndex == guy.XCoord))
                {
                    continue;
                }

                //Console.WriteLine($"Changing row index {rowIndex} column index: {columnIndex} to an obstruction");
                modifiedMap[rowIndex][columnIndex].Type = Space.SpaceType.Obstruction;

                var normalDude = new Dude()
                {
                    Heading = guy.Heading,
                    XCoord = guy.XCoord,
                    YCoord = guy.YCoord,
                };
                var fastDude = new Dude()
                {
                    Heading = guy.Heading,
                    XCoord = guy.XCoord,
                    YCoord = guy.YCoord,
                };

                while (true)
                {
                    Traverse(normalDude, modifiedMap);
                    var fastContinues = Traverse(fastDude, modifiedMap);
                    if (fastContinues == false)
                    {
                        break;
                    }
                    fastContinues = Traverse(fastDude, modifiedMap);
                    if (fastContinues == false)
                    {
                        break;
                    }
                    if (normalDude.XCoord == fastDude.XCoord &&
                        normalDude.YCoord == fastDude.YCoord &&
                        normalDude.Heading == fastDude.Heading)
                    {
                        cyclesCount++;
                        break;
                    }
                }
            }

            Console.WriteLine(cyclesCount);
        }

        public static void Day6P1()
        {
            var board = CreateBoard();
            var guy = board.Item1;
            var map = board.Item2;

            var keepMoving = true;
            while (keepMoving)
            {
                keepMoving = Traverse(guy, map);
            }

            var visitedCount = 0;
            foreach(var row in map)
            {
                visitedCount += row.Where(x => x.Visited).Count();
            }

            Console.WriteLine(visitedCount);
        }

        private static bool Traverse(Dude dude, List<List<Space>> map)
        {
            Space nextSpace = null;
            switch (dude.Heading)
            {
                case Dude.Direction.West:
                    if (dude.XCoord == 0)
                    {
                        //exits map
                        return false;
                    }
                    nextSpace = map[dude.YCoord][dude.XCoord - 1];
                    break;
                case Dude.Direction.North:
                    if (dude.YCoord == 0)
                    {
                        //exits map
                        return false;
                    }
                    nextSpace = map[dude.YCoord - 1][dude.XCoord];
                    break;
                case Dude.Direction.East:
                    if (dude.XCoord == map[0].Count - 1)
                    {
                        //exits map
                        return false;
                    }
                    nextSpace = map[dude.YCoord][dude.XCoord + 1];
                    break;
                case Dude.Direction.South:
                    if (dude.YCoord == map.Count - 1)
                    {
                        //exits map
                        return false;
                    }
                    nextSpace = map[dude.YCoord + 1][dude.XCoord];
                    break;
                default:
                    break;
            }

            switch (nextSpace.Type)
            {
                case Space.SpaceType.Empty:
                    nextSpace.Visited = true;
                    dude.XCoord = nextSpace.XCoord;
                    dude.YCoord = nextSpace.YCoord;
                    break;
                case Space.SpaceType.Obstruction:
                    dude.Rotate();
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
