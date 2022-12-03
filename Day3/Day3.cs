namespace Day3;

public static class Day3
{
    public static int Part1(string[] input)
    {
        var total = 0;
        foreach (var rucksack in input)
        {
            var duplicate = FindDuplicate(rucksack);
            total += GetPriority(duplicate);
        }

        return total;
    }

    public static int Part2(string[] input)
    {
        var currentGroup = new List<string>(3);
        var total = 0;
        for (int i = 0; i < input.Length; i++)
        {
            currentGroup.Add(input[i]);
            if (currentGroup.Count == 3)
            {
                var commonItem = FindCommon(currentGroup);
                total += GetPriority(commonItem);
                currentGroup.Clear();
            }
        }

        return total;
    }

    private static char FindDuplicate(string rucksack)
    {

            var totalItems = rucksack.Length;
            var itemsInEachCompartment = totalItems / 2;

            for (int compartment1Index = 0; compartment1Index < itemsInEachCompartment; compartment1Index++)
            {
                var item1 = rucksack[compartment1Index];
                for (int compartment2Index = itemsInEachCompartment; compartment2Index < rucksack.Length; compartment2Index++)
                {
                    var item2 = rucksack[compartment2Index];
                    if (item1 == item2) return item1;
                }
            }

            throw new InvalidDataException("Problem defines duplicate must always exist");
    }

    private static char FindCommon(IReadOnlyList<string> groupRucksacks)
    {
        foreach (var elf1Item in groupRucksacks[0])
        {
            foreach (var elf2Item in groupRucksacks[1])
            {
                foreach (var elf3Item in groupRucksacks[2])
                {
                    if (elf1Item == elf2Item && elf2Item == elf3Item) return elf1Item;
                }
            }
        }
        throw new InvalidDataException("Problem defines common item must always exist");
    }

    private static int GetPriority(char input)
    {
        if (char.IsUpper(input))
        {
            return input - 65 + 27;
        }
        return input - 96;
    }
}