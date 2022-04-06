using System;
using System.Collections;

namespace GridCreator
{
    class GridCreator
    {
        ArrayList validItems;
        ArrayList addedElements;
        string[,] grid;
        int attempts;

        public GridCreator()
        {
            initGrid();
        }

        private void initGrid()
        {
            refreshItems();
            addedElements = new ArrayList();
            grid = new string[4, 4];
            attempts = 0;
        }

        private void refreshItems()
        {
            validItems = new ArrayList() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        }

        public string[,] generateGrid()
        {
            initGrid();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string element = createRandomItem();
                    attempts++;
                    if (verticalPresent(element, j))
                    {
                        j = -1;
                        refreshItems();
                        clearRow(i);
                    } else if (isPresent(element))
                    {
                        j--;
                        validItems.Add(element[0]);
                        validItems.Add(element[1]);
                    } else
                    {
                        grid[i, j] = element;
                        addedElements.Add(element);
                    }
                    if (attempts > 150)
                        return generateGrid();
                }
                refreshItems();
            }
            return grid;
        }

        private string createRandomItem()
        {
            Random random = new Random();
            var letterOne = validItems[random.Next(validItems.Count)];
            validItems.Remove(letterOne);
            var letterTwo = validItems[random.Next(validItems.Count)];
            validItems.Remove(letterTwo);
            return letterOne.ToString() + letterTwo.ToString();
        }

        private bool verticalPresent(string element, int rowIndex)
        {
            var letterOne = element[0].ToString();
            var letterTwo = element[1].ToString();
            for (int i = 0; i < 4; i++)
            {
                if (grid[i, rowIndex] != null)
                {
                    if (grid[i, rowIndex].Contains(letterOne) ||
                    grid[i, rowIndex].Contains(letterTwo))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool isPresent(string element)
        {
            string reversedElement = element[1].ToString() + element[0].ToString();
            return addedElements.Contains(element) || addedElements.Contains(reversedElement);
        }

        private void clearRow(int rowIndex)
        {
            for (int i = 0; i < 4; i++)
            {
                if (grid[rowIndex, i]!=null)
                    addedElements.Remove(grid[rowIndex, i].ToString());
                grid[rowIndex, i] = null;
            }
        }

        public string[,] getGrid()
        {
            return grid;
        }
    }
}
