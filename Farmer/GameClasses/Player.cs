using System;
using System.Drawing;
using System.Windows.Forms;
using Farmer.Resources;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class Player
    {
        Point playerPos;
        Rectangle collisionRectangle, interactionRectangle, spriteRectangle;
        Bitmap playerSprite;
        //Pen collisionRectanglePen, interactionRectanglePen;

        int seedsValue, growthsValue, state, seedType;
        bool holdsWateringCan, stepPermission, interactionPermission, isRight;

        Gamefield gamefield;

        public delegate void ordinaryQuestion(Rectangle objectRectangle);
        public delegate void extendedQuestion(Rectangle objectRectangle, int value);
        public delegate bool createObject(Rectangle objectRectangle);

        public event ordinaryQuestion OnCollisionQuestion;
        public event extendedQuestion OnInteractionQuestionIO;
        public event extendedQuestion OnInteractionQuestionFC;

        public event createObject CreateObjectMessage;

        public Point PlayerPos { get => playerPos; }

        [Serializable]
        public enum State // заменить на русский
        {
            Руки    = 0,
            Мотыга  = 1,
            Лейка   = 2,
            Семена  = 3,
            Корзина = 4
        };

        public enum Seed
        {
            морковь     = 0,
            помидор     = 1,
            кукурузу    = 2
        };

        public Player(Gamefield gamefieldP)
        {
            playerPos.X = 50;
            playerPos.Y = 400;

            collisionRectangle = new Rectangle(playerPos.X, playerPos.Y, 32, 32);
            //collisionRectanglePen = new Pen(Color.Black, 2);

            interactionRectangle = new Rectangle(playerPos.X, playerPos.Y, 60, 60);
            //interactionRectanglePen = new Pen(Color.Red, 2);

            spriteRectangle = new Rectangle(0, 0, 32, 48);

            seedsValue = 0;
            growthsValue = 2;
            state = 1;
            seedType = 0;

            holdsWateringCan = false;
            stepPermission = true;
            isRight = false;

            playerSprite = Sprite.farmer_idle;

            gamefield = gamefieldP;
        }

        public void draw(Graphics graphics)
        {
            //graphics.DrawRectangle(collisionRectanglePen, collisionRectangle);
            //graphics.DrawRectangle(interactionRectanglePen, interactionRectangle);

            graphics.DrawImage(playerSprite, playerPos.X - 18, playerPos.Y - 38, spriteRectangle, GraphicsUnit.Pixel);
        }

        public bool KeyChecking(KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.W:
                    {
                        Rectangle tmpRectangle;
                        Point playerRectPos = new Point
                        {
                            X = playerPos.X - 16,
                            Y = playerPos.Y - 16
                        };

                        stepPermission = true;

                        tmpRectangle = new Rectangle(playerRectPos.X, playerRectPos.Y - 16, 32, 32);
                        spriteRectangle = new Rectangle(0, 144, 32, 48);

                        if (!this.gamefield.gameArea.Contains(tmpRectangle))
                            return false;

                        OnCollisionQuestion(tmpRectangle);

                        this.Move(tmpRectangle, 0, -16);

                        break;
                    }
                case Keys.A:
                    {
                        Rectangle tmpRectangle;
                        Point playerRectPos = new Point
                        {
                            X = playerPos.X - 16,
                            Y = playerPos.Y - 16
                        };

                        stepPermission = true;

                        tmpRectangle = new Rectangle(playerRectPos.X - 16, playerRectPos.Y, 32, 32);
                        spriteRectangle = new Rectangle(0, 48, 32, 48);

                        if (!this.gamefield.gameArea.Contains(tmpRectangle))
                            return false;

                        OnCollisionQuestion(tmpRectangle);

                        this.Move(tmpRectangle, -16, 0);

                        break;
                    }
                case Keys.S:
                    {
                        Rectangle tmpRectangle;
                        Point playerRectPos = new Point
                        {
                            X = playerPos.X - 16,
                            Y = playerPos.Y - 16
                        };

                        stepPermission = true;

                        tmpRectangle = new Rectangle(playerRectPos.X, playerRectPos.Y + 16, 32, 32);
                        spriteRectangle = new Rectangle(0, 0, 32, 48);

                        if (!this.gamefield.gameArea.Contains(tmpRectangle))
                            return false;

                        OnCollisionQuestion(tmpRectangle);

                        this.Move(tmpRectangle, 0, 16);

                        break;
                    }
                case Keys.D:
                    {
                        Rectangle tmpRectangle;
                        Point playerRectPos = new Point
                        {
                            X = playerPos.X - 16,
                            Y = playerPos.Y - 16
                        };

                        stepPermission = true;

                        tmpRectangle = new Rectangle(playerRectPos.X + 16, playerRectPos.Y, 32, 32);
                        spriteRectangle = new Rectangle(0, 96, 32, 48);

                        if (!this.gamefield.gameArea.Contains(tmpRectangle))
                            return false;

                        OnCollisionQuestion(tmpRectangle);

                        this.Move(tmpRectangle, 16, 0);

                        break;
                    }
                case Keys.Space:
                    {
                        switch(state)
                        {
                            case 0: // Hands
                                {
                                    OnInteractionQuestionIO(interactionRectangle, state);

                                    if (gamefield.intObjFieldCells[0] != null)
                                        OnInteractionQuestionFC(interactionRectangle, state);

                                    break;
                                }
                            case 1: // Hoe
                                {
                                    CreateObjectMessage(interactionRectangle);

                                    break;
                                }
                            case 2: // WateringCan
                                {
                                    try
                                    {
                                        OnInteractionQuestionFC(interactionRectangle, state);
                                    }
                                    catch { }

                                    break;
                                }
                            case 3: // Seed
                                {
                                    if (seedsValue < 1)
                                        return false;

                                    try
                                    {
                                        OnInteractionQuestionFC(interactionRectangle, state);
                                    }
                                    catch { }

                                    break;
                                }
                            case 4: // Harvest
                                {
                                    OnInteractionQuestionIO(interactionRectangle, state);

                                    break;
                                }
                        }

                        break;
                    }
                case Keys.D1:
                    {
                        state = 0;

                        break;
                    }
                case Keys.D2:
                    {
                        state = 1;

                        break;
                    }
                case Keys.D3:
                    {
                        state = 2;

                        break;
                    }
                case Keys.D4:
                    {
                        state = 3;

                        break;
                    }
                case Keys.D5:
                    {
                        state = 4;

                        break;
                    }
                case Keys.D8:
                    {
                        seedType = 0;

                        break;
                    }
                case Keys.D9:
                    {
                        seedType = 1;

                        break;
                    }
                case Keys.D0:
                    {
                        seedType = 2;

                        break;
                    }
            }
            return true;
        }

        public void Move(Rectangle playerRectangle, int pX, int pY)
        {
            if (stepPermission == true)
            {
                playerPos.X += pX;
                playerPos.Y += pY;

                collisionRectangle = playerRectangle;

                interactionRectangle = new Rectangle(playerPos.X - 30, playerPos.Y - 30, 60, 60);

                stepPermission = false;
            }
        }

        public int messageHandler(string eventWord, int value)
        {
            switch(eventWord)
            {
                case "stepPermission":
                    {
                        if (this.stepPermission == true && value >= 0 && value <= 1 )
                        {
                            switch (value)
                            {
                                case 0:
                                    {
                                        this.stepPermission = false;

                                        return 0;
                                    }
                                case 1:
                                    {
                                        this.stepPermission = true;

                                        return 1;
                                    }
                                default:
                                    return value;
                            }
                            
                        }

                        return 0;
                    }
                case "interactionPermission":
                    {
                        if (this.interactionPermission == true && value >= 0 && value <= 1)
                        {
                            switch (value)
                            {
                                case 0:
                                    {
                                        this.interactionPermission = false;

                                        return 0;
                                    }
                                case 1:
                                    {
                                        this.interactionPermission = true;

                                        return 1;
                                    }
                                default:
                                    return value;
                            }

                        }

                        return 0;
                    }
                case "seeds":
                    {
                        if (value >= -1 && seedsValue < 25)
                        {
                            seedsValue += value;
                        }
                        else
                        {
                            return seedType;
                        }
                        
                        return seedsValue;
                    }
                case "state":
                    {
                        return state;
                    }
                case "growths":
                    {
                        if (value > 0 && growthsValue < 10)
                        {
                            growthsValue += value;

                            return growthsValue;
                        }
                        if (value == 0)
                        {
                            value = growthsValue;
                            growthsValue = 0;

                            return value;
                        }

                        return growthsValue;
                    }
            }

            return 0;
        }
    }
}
