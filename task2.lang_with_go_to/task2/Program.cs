using System;
using System.IO;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("test.txt");
            string[] text_array = new string[1];
            int[] count_array = new int[1];
            int[][] page_array = new int[1][];
            int counter = 0;
            int page_counter = 1;
            char[] symbols = new char[]
            { ',' , '.' , ';', ':', '(', ')', '\'', '\\', '”', '&', '!', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '?'};

            int r = 0;
        lines:
            int i = 0;
            int k = 0;
            int length = 0;
            if (lines[r] != "")
            {
                try
                {
                find:
                    if (lines[r][i] < 1000000)
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
                if (lines[r][i] == ' ' || i == length - 1 || lines[r][i] == '\n')
                {
                    string world = "";
                    int char_counter = 0;
                world:

                    if (k < i || (i == length - 1 && k == i))
                    {
                        int h = 0;
                    symbol_check:
                        if (lines[r][k] == symbols[h])
                        {
                            k++;
                            goto world;
                        }
                        else if (h < 21)
                        {
                            h++;
                            goto symbol_check;
                        }

                        if (lines[r][k] >= 65 && lines[r][k] <= 90)
                        {
                            world += (char)(lines[r][k] + 32);
                        }
                        else
                        {
                            world += lines[r][k];
                            char_counter++;
                        }
                        k++;
                        goto world;
                    }
                    k = i + 1;
                    if (char_counter > 2 && world != "for" && world != "the" && world != "an"
                        && world != "a" && world != "and" && world != "in"
                        && world != "of" && world != "on" && world != "")
                    {
                        int f = 0;
                    check:
                        if (world == text_array[f])
                        {
                            count_array[f]++;
                            int[] tmp_array = new int[count_array[f]];
                            int g = 0;
                        new_arr:
                            tmp_array[g] = page_array[f][g];
                            if (g < count_array[f] - 2)
                            {
                                g++;
                                goto new_arr;
                            }
                            page_array[f] = tmp_array;
                            page_array[f][count_array[f] - 1] = page_counter;
                        }
                        else if (f < counter - 1)
                        {
                            f++;
                            goto check;
                        }
                        else
                        {
                            string[] temp_array = new string[counter + 1];
                            int[] temp_array2 = new int[counter + 1];
                            int[][] temp_array3 = new int[counter + 1][];
                            int d = 0;
                        new_array:
                            temp_array[d] = text_array[d];
                            temp_array2[d] = count_array[d];
                            temp_array3[d] = page_array[d];
                            if (d < counter - 1)
                            {
                                d++;
                                goto new_array;
                            }
                            text_array = temp_array;
                            count_array = temp_array2;
                            page_array = temp_array3;
                            text_array[counter] = world;
                            count_array[counter] = 1;
                            page_array[counter] = new int[1] { page_counter };
                            counter++;
                        }

                    }
                }
                i++;
                if (i < length)
                {
                    goto length;
                }
            }
            if (r > 45)
            {
                page_counter = r / 45;
            }
            if (r < lines.Length - 2)
            {
                r++;
                goto lines;
            }

            int a = 0;
            int tmp;
            string tmp2;
            int[] tmp3;
            char char1, char2;
        sortarr:
            if (a < counter - 2)
            {
                int b = a + 1;
            sortarrb:

                if (b < counter - 1)
                {
                    if (text_array[a][0] != text_array[b][0])
                    {
                        char1 = text_array[a][0];
                        char2 = text_array[b][0];
                    }
                    else if (text_array[a][1] != text_array[b][1])
                    {
                        char1 = text_array[a][1];
                        char2 = text_array[b][1];
                    }
                    else
                    {
                        char1 = text_array[a][2];
                        char2 = text_array[b][2];
                    }
                    if (char1 > char2)
                    {
                        tmp = count_array[a];
                        count_array[a] = count_array[b];
                        count_array[b] = tmp;
                        tmp2 = text_array[a];
                        text_array[a] = text_array[b];
                        text_array[b] = tmp2;
                        tmp3 = page_array[a];
                        page_array[a] = page_array[b];
                        page_array[b] = tmp3;
                    }
                    b++;
                    goto sortarrb;
                }
                a++;
                goto sortarr;
            }

            int j = 0;
        writeline:
            if (j < 1000)
            {
                if (count_array[j] <= 100)
                {
                    Console.Write(text_array[j] + " - ");
                    k = 0;
                write:
                    Console.Write(page_array[j][k] + " ");
                    if (j < count_array[j] - 1)
                    {
                        j++;
                        goto write;
                    }
                    Console.Write('\n');
                }
                j++;
                goto writeline;
            }
        }
    }
}

