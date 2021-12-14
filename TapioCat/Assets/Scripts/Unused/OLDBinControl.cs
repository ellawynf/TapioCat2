using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDBinControl : MonoBehaviour
{
    /*public GameObject Obj1C;        // tea 1/topping 1 cooking prefab
    public GameObject Obj1P;        // tea 1/topping 1 plating prefab
    //public Transform SP1C;          // tea 1/topping 1 cooking spawn point

    public GameObject Obj2C;        // tea 2/topping2  cooking prefab
    public GameObject Obj2P;        // tea 2/topping 2 plating prefab
    //p/ublic Transform SP2C;          // tea 2/topping 2 cooking spawn point

    public GameObject Obj3C;        // tea 3/topping 3 cooking prefab
    public GameObject Obj3P;        // tea 3/topping 3 plating prefab
    //public Transform SP3C;          // tea 3/topping 3 cooking spawn point

    public Transform SPP1_top;          // plate 1 topping spawn point
    public Transform SPP1_tea;          // plate 1 tea spawn point
    public Transform SPP2_top;          // plate 2 topping spawn point
    public Transform SPP2_tea;          // plate 2 tea spawn point

    private ObjectType thisObj;

    private void Start() {
        Obj1C.SetActive(false);
        Obj2C.SetActive(false);
        Obj3C.SetActive(false);
        thisObj = gameObject.GetComponent<ObjectType>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: implement switch from cooking to full
         if (other.CompareTag("Player")){


             if (gameObject.CompareTag("1")){         // topping 1/tea 1

                // tea 1
                if (thisObj.isTea){
                    if (GamePlay.tea1Cook == "empty"){          // empty; start cooking
                        Obj1C.SetActive(true);
                        GamePlay.tea1Cook = "cooking";

                    } else if (GamePlay.tea1Cook == "full"){    // full; grab
                        // TODO: grab; add some notif that it is full; MAKE SURE THIS IS RIGHT
                        if (GamePlay.plate1Tea == 0){         // checking plate 1
                            Obj1C.SetActive(false);                                 // destroy cooking tea 1
                            Instantiate(Obj1P, SPP1_tea.position, Obj1P.transform.rotation);                   // place tea 1 on plate 1
                            GamePlay.plate1Tea = "full";
                            GamePlay.tea1Cook = "empty";
                        } else if (GamePlay.plate2Tea == 0){      // checking plate 2
                            Obj1C.SetActive(false);                                 // destroy cooking tea 1
                            Instantiate(Obj1P, SPP2_tea.position, Obj1P.transform.rotation);                   // place tea 1 on plate 2
                            GamePlay.plate2Tea = "full";
                            GamePlay.tea1Cook = "empty";
                        }   // if neither available, do nothing
                    }   // cooking; do nothing                    
                } 
                // topping 1
                else {
                    if (GamePlay.topping1Cook == "empty"){          // empty; start cooking
                        Obj1C.SetActive(true);
                        GamePlay.topping1Cook = "cooking";

                    } else if (GamePlay.topping1Cook == "full"){    // full; grab
                        // TODO: grab; add some notif that it is full; MAKE SURE THIS IS RIGHT
                        if (GamePlay.plate1Topping == "empty"){         // checking plate 1
                            Obj1C.SetActive(false);                                 // destroy cooking topping 1
                            Instantiate(Obj1P, SPP1_top.position, Obj1P.transform.rotation);                   // place topping 1 on plate 1
                            GamePlay.plate1Topping = "full";
                            GamePlay.topping1Cook = "empty";
                        } else if (GamePlay.plate2Topping == "empty"){  // checking plate 2
                            Obj1C.SetActive(false);                                // destroy cooking topping 1
                            Instantiate(Obj1P, SPP2_top.position, Obj1P.transform.rotation);                   // place topping 1 on plate 2
                            GamePlay.plate2Topping = "full";
                            GamePlay.topping1Cook = "empty";
                        }   // if neither available, do nothing
                    }   // cooking; do nothing                    
                } 



             } else if (gameObject.CompareTag("2")){        // Topping 2/tea 2

                // tea 2
                if (thisObj.isTea){
                    if (GamePlay.tea2Cook == "empty"){          // empty; start cooking
                        Obj2C.SetActive(true);
                        GamePlay.tea2Cook = "cooking";

                    } else if (GamePlay.tea2Cook == "full"){    // full; grab
                        if (GamePlay.plate1Tea == "empty"){         // checking plate 1
                            Obj2C.SetActive(false);                                 // destroy cooking tea 2
                            Instantiate(Obj2P, SPP1_tea.position, Obj2P.transform.rotation);                   // place tea 2 on plate 1
                            GamePlay.plate1Tea = "full";
                            GamePlay.tea2Cook = "empty";
                        } else if (GamePlay.plate2Tea == "empty"){      // checking plate 2
                            Obj2C.SetActive(false);                                // destroy cooking tea 2
                            Instantiate(Obj2P, SPP2_tea.position, Obj2P.transform.rotation);                   // place tea 2 on plate 2
                            GamePlay.plate2Tea = "full";
                            GamePlay.tea2Cook = "empty";
                        }   // if neither available, do nothing
                    }
                } 
                // topping 2
                else {
                    if (GamePlay.topping2Cook == "empty"){          // empty; start cooking
                        Obj2C.SetActive(true);
                        GamePlay.topping2Cook = "cooking";

                    } else if (GamePlay.topping2Cook == "full"){    // full; grab
                        if (GamePlay.plate1Topping == "empty"){         // checking plate 1
                            Obj2C.SetActive(false);                                 // destroy cooking topping 2
                            Instantiate(Obj2P, SPP1_top.position, Obj2P.transform.rotation);                   // place topping 2 on plate 1
                            GamePlay.plate1Topping = "full";
                            GamePlay.topping2Cook = "empty";
                        } else if (GamePlay.plate2Topping == "empty"){  // checking plate 2
                            Obj2C.SetActive(false);                                 // destroy cooking topping 2
                            Instantiate(Obj2P, SPP2_top.position, Obj2P.transform.rotation);                   // place topping 2 on plate 2
                            GamePlay.plate2Topping = "full";
                            GamePlay.topping2Cook = "empty";
                        }   // if neither available, do nothing                    
                    }
                }


             } else if (gameObject.CompareTag("3")){        // Topping 3/tea 3

                // tea 3
                if (thisObj.isTea){
                    if (GamePlay.tea3Cook == "empty"){          // empty; start cooking
                        Obj3C.SetActive(true);
                        GamePlay.tea3Cook = "cooking";
                    } else if (GamePlay.tea3Cook == "full"){    // full; grab
                        if (GamePlay.plate1Tea == "empty"){         // checking plate 1
                            Obj3C.SetActive(false);                                 // destroy cooking tea 3
                            Instantiate(Obj3P, SPP1_tea.position, Obj3P.transform.rotation);                   // place tea 3 on plate 1
                            GamePlay.plate1Tea = "full";
                            GamePlay.tea3Cook = "empty";
                        } else if (GamePlay.plate2Tea == "empty"){      // checking plate 2
                            Obj3C.SetActive(false);                                 // destroy cooking tea 3
                            Instantiate(Obj3P, SPP2_tea.position, Obj3P.transform.rotation);                   // place tea 3 on plate 2
                            GamePlay.plate2Tea = "full";
                            GamePlay.tea3Cook = "empty";
                        }   // if neither available, do nothing
                    }
                }
                // topping 3
                else {
                    if (GamePlay.topping3Cook == "empty"){          // empty; start cooking
                        Obj3C.SetActive(true);
                        GamePlay.topping3Cook = "cooking";
                    } else if (GamePlay.topping3Cook == "full"){    // full; grab
                        if (GamePlay.plate1Topping == "empty"){         // checking plate 1
                            Obj3C.SetActive(false);                                // destroy cooking topping 3
                            Instantiate(Obj3P, SPP1_top.position, Obj3P.transform.rotation);                   // place topping 3 on plate 1
                            GamePlay.plate1Topping = "full";
                            GamePlay.topping3Cook = "empty";
                        } else if (GamePlay.plate2Topping == "empty"){  // checking plate 2
                            Obj3C.SetActive(false);                                 // destroy cooking topping 3
                            Instantiate(Obj3P, SPP2_top.position, Obj3P.transform.rotation);                   // place topping 3 on plate 2
                            GamePlay.plate2Topping = "full";
                            GamePlay.topping3Cook = "empty";
                        }   // if neither available, do nothing                    
                    }
                }
             }
        }       
    }*/
}
