using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class dataTarget : MonoBehaviour
    {

        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
            //add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

                //Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                TextTargetName.GetComponent<Text>().text = name;
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);


                //If the target name was “Butterfly” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the butterfly

                if (name == "Butterfly")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/butterfly"); });
                    TextDescription.GetComponent<Text>().text = "Scientific name of butterfly is 'RHOPALOCERA'. It's life span is 12 months. They don't have lungs and ears. But they can feel vibrartions & they can taste with their feet. ";
                }



                //If the target name was “Tiger” then add listener to ButtonAction with location of the unitychan sound (locate in Resources/sounds folder) and set text on TextDescription a description of the tiger

                if (name == "Tiger")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/tiger"); });
                    TextDescription.GetComponent<Text>().text = "Tiger can reach a length of up to 3.3 meters and weigh as much as 300 kilograms. It can jump up to 5 meters long. A group of tigers is known as ambush or streak.  ";
                }

                if (name == "Elephant")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/elephant"); });
                    TextDescription.GetComponent<Text>().text = "Life Span - elephants can live for up to 70 years. Males leave the herd between the ages of 12 and 15. Their tusks are of ivory and are actually enormously enlarged incisors. The elephant's eyes are small and its eyesight is poor. They have the largest brains in the animal kingdom ";
                }

                if (name == "Gorilla")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/gorilla"); });
                    TextDescription.GetComponent<Text>().text = "Gorillas are very smart and have been taught to use tools in captivity. A Gorilla can be 6ft tall and weigh 500 pounds. Gorillas can eat up to 50 pounds of food each day. Gorillas can live 35 years in the wild and over 50 years in captivity.";
                }

                if (name == "Rhino")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/rhino"); });
                    TextDescription.GetComponent<Text>().text = "A Rhino’s horn’s structure resembles a horse’s hooves. An adult rhino’s skin can be as much as 5 cm (2 inches) thick, with typical range of thickness across species being 1.5-5 cm thick. There are two species of white rhino: northern and southern. They can grow up to 15 feet long, stand over 6 feet tall and weigh over 7000 pounds (3.5 tons).";
                }

                if (name == "Horse")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/horse"); });
                    TextDescription.GetComponent<Text>().text = "Horses can sleep both lying down and standing up. Horses can run shortly after birth. Domestic horses have a lifespan of around 25 years. Horses have bigger eyes than any other mammal that lives on land. Because horse’s eyes are on the side of their head they are capable of seeing nearly 360 degrees at one time. Horses gallop at around 44 kph (27 mph).";
                }

                if (name == "Ladybug")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/bug"); });
                    TextDescription.GetComponent<Text>().text = "Ladybugs are a type of beetle. Some ladybugs have no spots and others have up to 20 spots.  The color of the ladybug sends off the message to its predators that it may taste bad or be poisonous.  When the temperature is near 60 degrees Fahrenheit or around 16 degrees Celsius, the ladybugs become active. To help defend themselves, ladybugs play dead. They also can release a yellow fluid that other bugs find stinky.";
                }
            }
        }

        //function to play sound
        void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }
    }
}

