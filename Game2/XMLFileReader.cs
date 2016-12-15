using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Content;
using Game3.Content;
using System.Xml;
using System.Linq;

namespace Robot_House_Touhou_Game
{
    class XMLFileReader
    {
        public void XMLREAD(List<string> list_enemyID, List<int> list_health, List<int> list_timecounter, List<bool> list_firing, List<int> list_number_of_enemies, List<string> list_path, List<Vector2> list_starting_Vector, List<string> list_bullet_path, List<string> list_bullet_attack)
        {
            string ID, health, timecounter, number_of_enemies, firing, path, starting_x, starting_y, repeats, bullet_paths, bullet_attacks;
            //XML reader needs to update the file location to make sure it works
            //IF YOU GET AN ERROR HERE
            // 1. Go to XML file in the solution explorer (the one with all the text)
            // 2. Right click, go to properties at the bottom
            // 3. Copy full path of XML file
            // 4. Paste between "" below
            using (XmlReader reader = XmlReader.Create("C:\\Users\\NIck\\OneDrive\\WSU Desktop\\final version!\\Rep_RobotHouse\\Game2\\XMLFile1.xml"))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "Level":
                                // Detect this element.
                                Console.WriteLine("Start <levels> element.");
                                break;
                            case "Wave":
                                // Detect this article element.
                                Console.WriteLine("Start <wave> element.");
                                // Search for the attribute name on this current node.
                                ID = reader["ID"];
                                health = reader["health"];
                                timecounter = reader["timecounter"];
                                number_of_enemies = reader["number_of_enemies"];
                                firing = reader["firing"];
                                path = reader["path"];
                                starting_x = reader["starting_x"];
                                starting_y = reader["starting_y"];
                                bullet_paths = reader["bullet_path"];
                                bullet_attacks = reader["bullet_attack"];
                                repeats = reader["repeat"];
                                if (ID != null)
                                {
                                    list_enemyID.Add(ID);
                                }

                                if (health != null)
                                {
                                    list_health.Add(Convert.ToInt32(health));
                                }

                                if (timecounter != null)
                                {
                                    list_timecounter.Add(Convert.ToInt32(timecounter));
                                }

                                if (number_of_enemies != null)
                                {
                                    list_number_of_enemies.Add(Convert.ToInt32(number_of_enemies));
                                }

                                if (bullet_paths != null)
                                {
                                    list_bullet_path.Add(bullet_paths);
                                }

                                if (bullet_attacks != null)
                                {
                                    list_bullet_attack.Add(bullet_attacks);
                                }


                                if (firing != null)
                                {
                                    if (firing == "true")
                                    {
                                        list_firing.Add(true);
                                    }
                                    else
                                    {
                                        list_firing.Add(false);
                                    }
                                }

                                if (path != null)
                                {
                                    list_path.Add(path);
                                }

                                if (starting_x != null)
                                {
                                    Vector2 temp;
                                    temp.X = Convert.ToInt32(starting_x);
                                    temp.Y = -50;
                                    list_starting_Vector.Add(temp);
                                }
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    Console.WriteLine("  Text node: " + reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}
