namespace AdventOfCode.Year2016.Day04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part2
    {
        public int GetSectorIdOfNorthPoleRoom(IEnumerable<string> inputs)
        {
            var rooms = new List<Room>();
            foreach (string input in inputs)
            {
                rooms.Add(GetRoom(input));
            }

            foreach (Room room in rooms)
            {
                Console.WriteLine(room.DecryptedName);

                if (room.DecryptedName.Equals("northpole object storage"))
                {
                    return room.SectorId;
                }
            }

            return 0;
        }

        private Room GetRoom(string input)
        {
            string checksum = input[input.IndexOf('[')..];
            string encryptedName = input.Replace(checksum, string.Empty);

            string[] encryptedParts = encryptedName.Split(['-'], StringSplitOptions.RemoveEmptyEntries);

            if (!int.TryParse(encryptedParts.Last(), out int sectorId))
            {
                throw new Exception($"Failed to parse {nameof(sectorId)} from {nameof(input)}: {input}");
            }

            return new Room(encryptedName.Replace($"-{sectorId}", string.Empty), sectorId);
        }

        private class Room(string encryptedName, int sectorId)
        {
            public string EncryptedName { get; } = encryptedName;

            public int SectorId { get; } = sectorId;
            
            public string DecryptedName
            {
                get
                {
                    var decryptedName = new List<char>();
                    for (int i = 0; i < EncryptedName.Length; i++)
                    {
                        if (EncryptedName[i] == '-')
                        {
                            decryptedName.Add(' ');
                        }
                        else
                        {
                            decryptedName.Add((char)(((EncryptedName[i] - 'a' + SectorId) % 26) + 'a'));
                        }
                    }

                    return new string([.. decryptedName]);
                }
            }
        }
    }
}