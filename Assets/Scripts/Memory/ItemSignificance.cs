using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for accessing the EventSystem
using TMPro;

public class ItemSignificance : MonoBehaviour
{
    public TextMeshProUGUI itemName, itemSignificance;
    public void LogSourceImageName()
    {
        GameObject clickedGameObject = EventSystem.current.currentSelectedGameObject;
        

        if (clickedGameObject == null)
        {
            Debug.LogWarning("No GameObject was selected. This method should only be called by a Button.");
            return;
        }

        Button clickedButton = clickedGameObject.GetComponent<Button>();

        if (clickedButton != null)
        {
            Image buttonImage = clickedButton.image;

            if (buttonImage != null && buttonImage.sprite != null)
            {
                string imageName = buttonImage.sprite.name;
                Debug.Log($"Button '{clickedGameObject.name}' clicked. Source Image Name: {imageName}");

                int name = int.Parse(imageName);
                switch (name)
                {
                    case 1:
                        itemName.SetText("Ship");
                        itemSignificance.SetText("The ship, Bapor Tabo, is crucial to the story's beginning. Onboard, we meet the mysterious jeweler Simoun, friars Padre Salvi and Padre Sibyla, journalists Ben - Zayb and Don Custodio, socialite Doña Victorina with her niece Paulita Gomez, and young idealists Isagani and Basilio. The crowded ship reflects Philippine society. The diverse characters represent different social classes and beliefs, showcasing main conflicts.");
                        break;
                    case 2:
                        itemName.SetText("Duck");
                        itemSignificance.SetText("The discussion on the ship revolves around the Pasig River, which is becoming silted. Simoun proposed using forced labor, while Don Custodio suggested raising ducks to eat the snails that help deepen the river.");
                        break;
                    case 3:
                        itemName.SetText("Pot");
                        itemSignificance.SetText("The scene shifts to the lower deck, which is hot, noisy, and where the poor are. It's a stark contrast to the comfortable upper deck of the rich. The pot down there symbolizes the hardship of the common people. ");
                        break;
                    case 4:
                        itemName.SetText("Beer");
                        itemSignificance.SetText("The beer represents true strength. Padre Camorra claimed that Filipinos were weak for drinking water instead of beer. However, Isagani countered, “Water is sweet and drinkable, but it drowns beer and extinguishes fire.");
                        break;
                    case 5:
                        itemName.SetText("Stone");
                        itemSignificance.SetText("The legend of San Nicolas turning crocodiles to stone for a Chinese merchant, it illustrates the transition to Catholicism while showing how superstition was used for manipulation. The rock represents obstacles to truth and liberation, keeping people in ignorance. ");
                        break;
                    case 6:
                        itemName.SetText("Money");
                        itemSignificance.SetText("Simoun is introduced as a rich and influential figure with connections to the Governor-General. This wealth grants him a seat on the upper deck of the steamer with the colonial elite, giving him access and influence over the very officials he plans to overthrow.");
                        break;
                    case 7:
                        itemName.SetText("Plant");
                        itemSignificance.SetText("Cabesang Tales. He's the son of Tandang Selo who once helped Basilio when he was a child. The plant represents Cabesang Tales' hard work, as he cultivates a flourishing sugarcane plantation. However, the friars claim his land and keep raising taxes until it's unaffordable. ");
                        break;
                    case 8:
                        itemName.SetText("Axe");
                        itemSignificance.SetText("The axe was used by Cabesang Tales when he couldn't pay the friars' taxes to guard his land. However, he was soon abducted by bandits who mistakenly thought he had money from hiring a lawyer and demanded a ransom. ");
                        break;
                    case 9:
                        itemName.SetText("Necklace");
                        itemSignificance.SetText("Juli, Cabesang Tales' daughter, sold all her jewelry but her cherished necklace from Basilio (her lover) to pay for the ransom. When funds were short, she became a maid for Hermana Penchang, sacrificing her education. ");
                        break;
                    case 10:
                        itemName.SetText("Carriage");
                        itemSignificance.SetText("On Christmas Eve, Basilio returns to San Diego by carriage, observing the town's conditions and the struggles of the people. He learns about the arrest of Kabesang Tales, the father of his lover, Juli. ");
                        break;
                    case 11:
                        itemName.SetText("Stethoscope");
                        itemSignificance.SetText("The stethoscope symbolizes Basilio's final year of medical studies and his dream of becoming a doctor, embodying his hope for a better life for himself and Juli, whom he plans to marry after graduation. ");
                        break;
                    case 12:
                        itemName.SetText("Shovel");
                        itemSignificance.SetText("The shovel is intended for Basilio when he discovers Simoun digging at Sisa's grave. It symbolizes the uncovering of secrets as Simoun reveals his true identity as Ibarra, who has returned to overthrow the corrupt government. ");
                        break;
                    case 13:
                        itemName.SetText("Woven Bag");
                        itemSignificance.SetText("The woven bag is for Juli as she packs her belongings for work, hoping her absence won't last long, but sadness overcomes her. Tandang Selo, overwhelmed by his poverty and Juli's departure, became unable to speak—his voice was gone.  ");
                        break;
                    case 14:
                        itemName.SetText("Basiong Makunat");
                        itemSignificance.SetText("Tandang Basiong Makunat book was widely used to teach blind obedience and outdated beliefs. Simoun included it to highlight how education can be used to suppress rather than enlighten. ");
                        break;
                    case 15:
                        itemName.SetText("Gem");
                        itemSignificance.SetText(" In the past, jewels like this often-symbolized greed and false hopes. Simoun used them to tempt the powerful and trap them. ");
                        break;
                    case 16:
                        itemName.SetText("Gun");
                        itemSignificance.SetText("It's definitely not a toy. In the past, weapons like that show how close people were to taking justice into their own hands. It's a quiet threat of rebellion. ");
                        break;
                    case 17:
                        itemName.SetText("Playing Cards");
                        itemSignificance.SetText("Games, gamble, bluff,  that’s exactly what the powerful figures in Los Baños were doing not with cards, but with people's lives and futures. They treated the students’ petition like a joke, laughing over it during a fancy banquet. They made promises they never intended to keep. It was all a game to them. ");
                        break;
                    case 18:
                        itemName.SetText("Spanish book");
                        itemSignificance.SetText("That book represents the colonial system, its rules, its control, its image of authority. The book appears important, but it’s empty of real change. In the chapter, the Governor-General and other leaders acted as though they were listening to reformers, but all they did was mock the petition while following the same old system. ");
                        break;
                    case 19:
                        itemName.SetText("Statue");
                        itemSignificance.SetText("A monument dedicated to a Dominican priest. It was funded by the people, and Juanito Pelaez collected the contributions. ");
                        break;
                    case 20:
                        itemName.SetText("Pen");
                        itemSignificance.SetText("That pen was meant to sign a document opposing Makaraig’s plan to build the Spanish language academy. Placido didn’t sign it. He said he had no time to read it—so he refused to use the pen. ");
                        break;
                    case 21:
                        itemName.SetText("Physics");
                        itemSignificance.SetText(" In the past, the school tried to explain science but twisted facts to support cruelty. Even knowledge was corrupted. ");
                        break;
                    case 22:
                        itemName.SetText("Two Storey House");
                        itemSignificance.SetText("Homes like that separated the rich from the poor. It’s a silent critique of the social walls people built to keep others out. ");
                        break;
                    case 23:
                        itemName.SetText("Japan Flag");
                        itemSignificance.SetText("It symbolized escape. Japan represented a country with independence something our characters could only dream about. ");
                        break;
                    case 24:
                        itemName.SetText("Ferris Wheel");
                        itemSignificance.SetText("A fair distracted the public from injustice. While people laughed, their freedoms were being stolen. ");
                        break;
                    case 25:
                        itemName.SetText("Circus Ticket");
                        itemSignificance.SetText("The circus wasn’t just entertainment it was a tool to keep people happy while deeper problems festered. A shiny cover hiding darkness.");
                        break;
                    case 26:
                        itemName.SetText("Wooden box");
                        itemSignificance.SetText("Sometimes the box is more about what it hides. Secrets, plans, or maybe someone's guilt it’s a metaphor for hidden truths. ");
                        break;
                    case 27:
                        itemName.SetText("Lion Man");
                        itemSignificance.SetText("That’s a sphinx a symbol of riddles and mysteries. In the past, many people wore masks to hide their real intentions. ");
                        break;
                    case 28:
                        itemName.SetText("Letter");
                        itemSignificance.SetText("Letters held power back then. One message could ruin a life or start a rebellion. It’s amazing how something so small could be so dangerous. ");
                        break;
                    case 29:
                        itemName.SetText("Quill Pen");
                        itemSignificance.SetText("That quill could’ve written words that changed minds. Ideas, once written down, can spread like wildfire especially during times of unrest.");
                        break;
                    case 30:
                        itemName.SetText("Theatre");
                        itemSignificance.SetText("The stage was where truths came out but also where lies were performed. It reflected the hypocrisy of society. ");
                        break;
                    case 31:
                        itemName.SetText("Empty box");
                        itemSignificance.SetText("It’s a symbol of empty promises, or of people left with nothing after putting their trust in the wrong hands.");
                        break;
                    case 32:
                        itemName.SetText("Utensils");
                        itemSignificance.SetText(" In the past  food and dining tools show class divisions who had too much, and who had nothing. ");
                        break;
                    case 33:
                        itemName.SetText("Poison");
                        itemSignificance.SetText("Poison, like secrets, can be silent and deadly. It represented Simoun’s willingness to do whatever it took to spark change. ");
                        break;
                    case 34:
                        itemName.SetText("Dove of Peace");
                        itemSignificance.SetText("Peace was always just out of reach. That dove symbolizes the dream of unity that everyone chased but no one could grasp. ");
                        break;
                    case 35:
                        itemName.SetText("Bolo knife");
                        itemSignificance.SetText("It’s a symbol of resistance. When all else failed, the oppressed were prepared to fight with whatever they had. ");
                        break;
                    case 36:
                        itemName.SetText("Soldier hat");
                        itemSignificance.SetText("That hat belonged to someone who once had authority. But just like power, it fades with time if not used for good. ");
                        break;
                    case 37:
                        itemName.SetText("Heart");
                        itemSignificance.SetText("It could represent love, sacrifice, or heartbreak. Many people in the past had to choose between love and justice. ");
                        break;
                    case 38:
                        itemName.SetText("Philippine Map");
                        itemSignificance.SetText("That’s what they were fighting for a vision of a free, united country. It's the dream at the heart of every struggle. ");
                        break;
                    case 39:
                        itemName.SetText("Trophy");
                        itemSignificance.SetText("Victory isn’t always clean. This might show how some wins come at the cost of values—or lives.");
                        break;
                    case 40:
                        itemName.SetText("Pancit");
                        itemSignificance.SetText("It could mean more like cultural traditions, or the secret meetings held over simple meals. ");
                        break;
                    case 41:
                        itemName.SetText("Crab");
                        itemSignificance.SetText("It’s a warning. Crab mentality when people pull each other down was a problem then, and still is now. We have to rise together. ");
                        break;
                    case 42:
                        itemName.SetText("Piggy Bank");
                        itemSignificance.SetText("It symbolizes the money Basilio borrowed from Makaraeg—his hope to finish his studies and it holds Basilio’s dreams and sacrifices. ");
                        break;
                    case 43:
                        itemName.SetText("Posters");
                        itemSignificance.SetText("The poster is a symbol of rebellion—it voiced out what the students couldn’t say aloud.");
                        break;
                    case 44:
                        itemName.SetText("Graduation Cap");
                        itemSignificance.SetText("It represents his dream—to finish his studies and finally rise above hardship. ");
                        break;
                    case 45:
                        itemName.SetText("Rosary");
                        itemSignificance.SetText("The rosary symbolizes the friar himself—presenting holiness on the outside but hiding control and abuse underneath. ");
                        break;
                    case 46:
                        itemName.SetText("Student ID");
                        itemSignificance.SetText("It symbolizes Isagani and the other students—their identity, their right to education, and their voice in society. The system fears educated Filipinos, so it tries to silence them—even if they carry the ID of a student. ");
                        break;
                    case 47:
                        itemName.SetText("Rope");
                        itemSignificance.SetText("The rope symbolizes death—because speaking the truth, like what Isagani did, often leads to punishment. ");
                        break;
                    case 48:
                        itemName.SetText("Newspaper");
                        itemSignificance.SetText("It symbolizes how the media can spread fear—especially when journalists like Ben Zayb write exaggerated or false stories. ");
                        break;
                    case 49:
                        itemName.SetText("Fear emoji");
                        itemSignificance.SetText("It perfectly represents the emotion in this chapter—widespread fear after the paskin and the woman’s death. ");
                        break;
                    case 50:
                        itemName.SetText("Folding fan");
                        itemSignificance.SetText("It symbolizes the quiet suffering of women during those times—graceful on the outside, but victims of a fearful and unjust society. ");
                        break;
                    case 51:
                        itemName.SetText("Tombstone");
                        itemSignificance.SetText("It symbolizes Kapitan Tiago’s grave, his death, but also how society pretends to honor him as a good man—despite his corrupt and selfish life.");
                        break;
                    case 52:
                        itemName.SetText("Window");
                        itemSignificance.SetText("It symbolizes Juli's longing for freedom, a view of a better life that was always out of reach. It became a symbol of escape from a world that offered her no mercy. ");
                        break;
                    case 53:
                        itemName.SetText("Europe");
                        itemSignificance.SetText(" It represents the hope for change—because Europe, to many Filipinos like the high officials or students, symbolizes justice and progress. While the Philippines suffers under corruption, the map of Europe reminds them of the freedom they long for. ");
                        break;
                    case 54:
                        itemName.SetText("Key");
                        itemSignificance.SetText("The key represents freedom—it symbolizes the release of the students who were unjustly imprisoned. The key shows that even in a corrupt system, there are still people who choose justice.");
                        break;
                    case 55:
                        itemName.SetText("Shield");
                        itemSignificance.SetText("It symbolizes the defense of truth—how some high officials began to protect Basilio and question the unfair punishment. ");
                        break;
                    case 56:
                        itemName.SetText("Rice Plant");
                        itemSignificance.SetText("It symbolizes the return to a simpler life—many students stopped studying and turned to farming out of fear and pressure. The rice plant reflects how dreams of change were set aside for survival, especially by students like Pecson, Tadeo, and Pelaez. ");
                        break;
                    case 57:
                        itemName.SetText("Airplane");
                        itemSignificance.SetText("It represents escape and opportunity—while others gave up, Makaraeg flew to Europe to continue his dreams. The airplane shows that while some dreams were grounded, Makaraeg’s ambition kept flying.");
                        break;
                    case 58:
                        itemName.SetText("Mask");
                        itemSignificance.SetText("It symbolizes how people—especially students and parents—hid their true feelings out of fear. Society forced them to stay silent and pretend, just to stay safe. ");
                        break;
                    case 59:
                        itemName.SetText("Wedding Cake");
                        itemSignificance.SetText("It symbolizes the students’ future plans—goals of success, love, and celebration that were ruined by fear and injustice. The wedding cake remains untouched—just like their dreams that were never fulfilled. ");
                        break;
                    case 60:
                        itemName.SetText("Dirty Clothes");
                        itemSignificance.SetText("They represent the people who claim to fight for justice, but their actions are stained with selfishness and corruption. Padre Florentino reminds us that true righteousness isn’t shown on the outside, but in the purity of one’s intentions. ");
                        break;
                    case 61:
                        itemName.SetText("Lamp");
                        itemSignificance.SetText("It symbolizes light in the darkness—Padre Florentino’s wisdom and moral integrity in a time of chaos.  The lampara shines as a symbol of truth and hope when everything else is falling apart. ");
                        break;
                    case 62:
                        itemName.SetText("Sword");
                        itemSignificance.SetText("It symbolizes Simoun’s desire to change society through violence—but in the end, it failed. Padre Florentino shows that true change comes not from the sword, but from a clean heart and just purpose. ");
                        break;
                    case 63:
                        itemName.SetText("Wedding Bouquet");
                        itemSignificance.SetText("The wedding bouquet represents the grand wedding of Paulita Gomez and Juanito Pelaez. On the surface, it’s a moment of beauty and celebration. But for Isagani, Paulita’s former lover, it’s a symbol of heartbreak and betrayal.");
                        break;
                    case 64:
                        itemName.SetText("Horse");
                        itemSignificance.SetText("The horse refers to the carriages and chaos outside the church. After Simoun places the explosive lamp under the wedding table, people start panicking. Horses run wild, guests scream, and everything turns to disorder. ");
                        break;
                    case 65:
                        itemName.SetText("Furniture");
                        itemSignificance.SetText("The reception was held in a lavish home filled with Spanish-era furniture symbols of wealth, power, and colonial luxury. But beneath all that elegance was Simoun’s bomb, hidden in a lamp under the table");
                        break;
                    case 66:
                        itemName.SetText("Tea Mug");
                        itemSignificance.SetText("These come from the time where Simoun, wounded and hiding, is taken in by Padre Florentino. They drink tea together as Simoun slowly opens up. ");
                        break;
                    case 67:
                        itemName.SetText("Mane Thacel Phares");
                        itemSignificance.SetText("That phrase comes from the Bible. It means You have been weighed and found wanting. Simoun writes it as his final message a judgment against the corrupt society he failed to change. ");
                        break;
                    case 68:
                        itemName.SetText("Shadow");
                        itemSignificance.SetText("The shadow represents his past, his guilt, his inner darkness. Even as he confesses, it stays with him. Simoun cannot escape what he became but by confessing, he hopes the next generation won’t follow his path. ");
                        break;
                    case 69:
                        itemName.SetText("Lion");
                        itemSignificance.SetText("The lion represents bravery. In the end, it wasn’t Simoun who was the bravest it was Padre Florentino. He stood firm in his beliefs, refusing to support revenge or corruption, and chose to throw Simoun’s treasure into the sea.");
                        break;
                    case 70:
                        itemName.SetText("Pen and Paper");
                        itemSignificance.SetText("Padre Florentino tells Simoun that the future belongs to those who suffer and fight for justice using wisdom, not violence. The pen becomes the symbol of hope like some of the nation's heroes, who wrote to awaken the nation. ");
                        break;
                    case 71:
                        itemName.SetText("Bullet");
                        itemSignificance.SetText("That bullet represents Simoun’s past his anger, his violence, his failed revolution. It reminds us that violence may bring fear, but never true change. ");
                        break;
                    case 72:
                        itemName.SetText("Earring");
                        itemSignificance.SetText("The earring symbolizes the remnants of the past a piece of beauty that survives. Just like Simoun's story his dreams shattered, but traces of his identity, like Ibarra’s hope, still linger. The earring reminds us that even after loss, something remains a spark of what once mattered. ");
                        break;
                    case 73:
                        itemName.SetText("Bayong");
                        itemSignificance.SetText("The bayong, a common item used daily, symbolizes the ordinary people those who carry the burdens of injustice quietly. While others hold power, it’s the people who live with the consequences. ");
                        break;
                    case 74:
                        itemName.SetText("Rifle with Bayonet");
                        itemSignificance.SetText("It represents the brutal response of the authorities. After Simoun’s failure, the government tightens control arrests are made, suspects tortured, people silenced. ");
                        break;
                    case 75:
                        itemName.SetText("Warning");
                        itemSignificance.SetText("The warning sign is for all of us it says: If we do not act with wisdom, if we do not learn from the past, then we will face destruction not just from our enemies,but from ourselves.");
                        break;
                    case 76:
                        itemName.SetText("Telegram");
                        itemSignificance.SetText("During those times, telegrams were used for fast, urgent messages. It symbolizes news, usually too late like warnings ignored, or truths realized only after tragedy. It could symbolize the cry for help of the youth, or Simoun’s final thoughts lost in the chaos and only arriving after everything’s over. ");
                        break;
                    case 77:
                        itemName.SetText("Maria Clara");
                        itemSignificance.SetText("Maria Clara represents love, innocence, and the country’s lost soul. The photo frame reminds us of everything that Simoun once Ibarra fought for.");
                        break;
                    case 78:
                        itemName.SetText("Candle");
                        itemSignificance.SetText("A candle gives light but it also melts as it burns. It represents life, faith, and sacrifice. Padre Florentino may have lit one for Simoun’s soul. ");
                        break;
                    case 79:
                        itemName.SetText("Suitcase");
                        itemSignificance.SetText("The suitcase is the final choice to leave or to stay. Many Filipinos in the past fled, others stayed to fight in different ways. It represents that moment of decision: Do I continue this fight… or walk away ? ");
                        break;

                    default:
                        Debug.LogWarning("Button is not handled.");
                        break;
                }
            }
            else
            {
                Debug.LogWarning($"Button '{clickedGameObject.name}' clicked, but its Image component or Sprite is missing.");
            }
        }
        else
        {
            Debug.LogError("The clicked object does not have a Button component.");
        }
    }
}