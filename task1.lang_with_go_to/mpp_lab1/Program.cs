using System;

namespace mpp_lab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] text_array = new string[1];
            int[] count_array = new int[1];
            int i = 0;
            int k = 0;
            int numb = 1;
            int length = 0;

            try
            {
                find:
                if (text[i] < 1000000)
                {
                    i++;
                    length++;
                    goto find;
                }
            }
            catch (IndexOutOfRangeException)
            {
                i = 0;
                goto length;
            }

        length:
            if (text[i] == ' ' || text[i] == '\n' || i == length - 1)
            {
                string world = "";

            world:

                if (k < i || (i == length - 1 && k == i))
                {
                    if (text[k] != ',' && text[k] != '.')
                    {
                        if (text[k] >= 65 && text[k] <= 90)
                        {
                            world += (char)(text[k] + 32);
                        }
                        else
                        {
                            world += text[k];
                        }
                    }
                    k++;
                    goto world;
                }
                k = i + 1;
                if (world != "for" && world != "the" && world != "an"
                    && world != "a" && world != "and" && world != "in"
                    && world != "of" && world != "on")
                {
                    string[] temp_array = new string[numb];
                    int d = 0;
                new_array2:
                    temp_array[d] = text_array[d];
                    if (d < numb - 2)
                    {
                        d++;
                        goto new_array2;
                    }
                    text_array = temp_array;
                    text_array[numb - 1] = world;
                    numb++;
                }
            }

            i++;

            if (i < length)
            {
                goto length;
            }

            string current;
            int j = 0;
            string[] new_text = new string[1];
            int counter = 1;

        count:
            if (j < numb - 1)
            {
                current = text_array[j];
                int f = 0;
            check:
                if (current == new_text[f])
                {
                    count_array[f]++;
                    j++;
                    goto count;
                }
                else if (f < counter - 2)
                {
                    f++;
                    goto check;
                }
                else
                {
                    string[] temp_array = new string[counter];
                    int[] temp_array2 = new int[counter];
                    int d = 0;
                new_array:
                    temp_array[d] = new_text[d];
                    temp_array2[d] = count_array[d];
                    if (d < counter - 2)
                    {
                        d++;
                        goto new_array;
                    }
                    new_text = temp_array;
                    count_array = temp_array2;
                    new_text[counter - 1] = current;
                    count_array[counter - 1] = 1;
                    counter++;
                }
                j++;
                goto count;
            }

            int a = 0;
            int tmp;
            string tmp2;
        sortarr:
            if (a < counter - 2)
            {
                int b = a + 1;
            sortarrb:
                
                if (b < counter - 1)
                {
                    if (count_array[a] < count_array[b])
                    {
                        tmp = count_array[a];
                        count_array[a] = count_array[b];
                        count_array[b] = tmp;
                        tmp2 = new_text[a];
                        new_text[a] = new_text[b];
                        new_text[b] = tmp2;
                    }
                    b++;
                    goto sortarrb;
                }
                a++;
                goto sortarr;
            }

            i = 0;
        writeline:
            if (i < counter - 1 && i < 25)
            {
                Console.WriteLine((i + 1) + ". " + new_text[i] + " - " + count_array[i]);
                i++;
                goto writeline;
            }
        }
    }
}
