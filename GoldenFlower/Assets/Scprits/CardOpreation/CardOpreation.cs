/** 
 *Copyright(C) 2017 by YX  
 *FileName:     CardOpreation.cs 
 *Author:       chenyongjun 
 *Version:      2.0 
 *UnityVersion：5.6.0f3 
 *Date:         2017-12-13 
 *Description:    
 *History: 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 卡牌操作
/// </summary>
public class CardOpreation
{
    /// <summary>
    /// 获取卡牌的类型
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static CardsTypeEnum GetCardsType(List<CardInfo> cards)
    {
        CardsTypeEnum result = CardsTypeEnum.单张;
        if (isBaoZi(cards))
        {
            result = CardsTypeEnum.豹子;
        }
        else if (isShunJin(cards))
        {
            result = CardsTypeEnum.顺金;
        }
        else if (isJinHua(cards))
        {
            result = CardsTypeEnum.金花;
        }
        else if (isShunZi(cards))
        {
            result = CardsTypeEnum.顺子;
        }
        else if (isDui(cards))
        {
            result = CardsTypeEnum.对对;
        }
        return result;
    }
    /// <summary>
    /// 判断是否豹子
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool isBaoZi(List<CardInfo> cards)
    {
        bool result = false;
        var flag = cards[0].cardNumber;
        for (int i = 1; i < cards.Count; i++)
        {
            if (flag != cards[i].cardNumber)
            {
                result = false;
                break;
            }
            else
            {
                result = true;
            }
        }
        return result;
    }
    /// <summary>
    /// 判断是否顺金
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool isShunJin(List<CardInfo> cards)
    {
        bool result = false;
        if (isJinHua(cards) && isShunZi(cards))
        {
            result = true;
        }
        return result;
    }

    /// <summary>
    /// 判断是否金花
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool isJinHua(List<CardInfo> cards)
    {
        bool result = false;
        var flag = cards[0].cardColor;
        for (int i = 1; i < cards.Count; i++)
        {
            if (flag != cards[i].cardColor)
            {
                result = false;
                break;
            }
            else
            {
                result = true;
            }
        }
        return result;
    }

    /// <summary>
    /// 判断是否顺子
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool isShunZi(List<CardInfo> cards)
    {
        bool result = false;
        int[] numbers = new int[cards.Count];
        for (int i = 0; i < cards.Count; i++)
        {
            int a = (int)cards[i].cardNumber;
            numbers[i] = a;
        }
        int flag = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    flag = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = flag;
                }
            }
        }
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] == (numbers[i + 1] - 1))
            {
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }
        return result;
    }

    /// <summary>
    /// 判断是否对对
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool isDui(List<CardInfo> cards)
    {
        bool result = false;
        int[] numbers = new int[cards.Count];
        for (int i = 0; i < cards.Count; i++)
        {
            int a = (int)cards[i].cardNumber;
            numbers[i] = a;
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    result = true;
                }
            }
        }
        return result;
    }
    /// <summary>
    /// 玩家比牌 (需提取数组操作方法)
    /// </summary>
    /// <param name="activeCards">主动比牌的玩家牌</param>
    /// <param name="passiveCards">被动比牌的玩家牌</param>
    /// <returns></returns>
    public static bool matchCards(List<CardInfo> activeCards, List<CardInfo> passiveCards)
    {
        bool result = false;
        CardsTypeEnum activeType = GetCardsType(activeCards);
        CardsTypeEnum passiveType = GetCardsType(passiveCards);
        int activeNumber = (int)activeType;
        int passiveNumber = (int)passiveType;
        if (activeNumber > passiveNumber)
        {
            result = true;
        }
        else if (activeNumber < passiveNumber)
        {
            result = false;
        }
        else
        {
            if (activeType == CardsTypeEnum.豹子)
            {
                activeNumber = (int)activeCards[0].cardNumber;
                passiveNumber = (int)passiveCards[0].cardNumber;
                if (activeNumber > passiveNumber)
                {
                    result = true;
                }
            }
            else if (activeType == CardsTypeEnum.顺金 || activeType == CardsTypeEnum.顺子)
            {
                int[] activeCardNumbers = new int[activeCards.Count];
                for (int i = 0; i < activeCards.Count; i++)
                {
                    activeCardNumbers[i] = (int)activeCards[i].cardNumber;
                }
                int activeCardMaxNumber = activeCardNumbers[0];
                for (int j = 1; j < activeCardNumbers.Length; j++)
                {
                    if (activeCardNumbers[j] > activeCardMaxNumber)
                    {
                        activeCardMaxNumber = activeCardNumbers[j];
                    }
                }

                int[] passiveCardNumbers = new int[passiveCards.Count];
                for (int i = 0; i < passiveCards.Count; i++)
                {
                    passiveCardNumbers[i] = (int)passiveCards[i].cardNumber;
                }
                int passiveCardMaxNumber = passiveCardNumbers[0];
                for (int j = 1; j < passiveCardNumbers.Length; j++)
                {
                    if (passiveCardNumbers[j] > passiveCardMaxNumber)
                    {
                        passiveCardMaxNumber = passiveCardNumbers[j];
                    }
                }
                if (activeCardMaxNumber > passiveCardMaxNumber)
                {
                    result = true;
                }
            }
            else if (activeType == CardsTypeEnum.金花 || activeType == CardsTypeEnum.单张)
            {
                int[] activeCardNumbers = new int[activeCards.Count];
                for (int i = 0; i < activeCards.Count; i++)
                {
                    activeCardNumbers[i] = (int)activeCards[i].cardNumber;
                }

                int[] passiveCardNumbers = new int[passiveCards.Count];
                for (int i = 0; i < passiveCards.Count; i++)
                {
                    passiveCardNumbers[i] = (int)passiveCards[i].cardNumber;
                }
                int temp = 0;
                for (int i = 0; i < activeCardNumbers.Length; i++)
                {
                    for (int j = i + 1; j < activeCardNumbers.Length; j++)
                    {
                        if (activeCardNumbers[j] > activeCardNumbers[i])
                        {
                            temp = activeCardNumbers[i];
                            activeCardNumbers[i] = activeCardNumbers[j];
                            activeCardNumbers[j] = temp;
                        }
                    }
                }
                for (int i = 0; i < passiveCardNumbers.Length; i++)
                {
                    for (int j = i + 1; j < passiveCardNumbers.Length; j++)
                    {
                        if (passiveCardNumbers[j] > passiveCardNumbers[i])
                        {
                            temp = passiveCardNumbers[i];
                            passiveCardNumbers[i] = passiveCardNumbers[j];
                            passiveCardNumbers[j] = temp;
                        }
                    }
                }
                for (int i = 0; i < activeCardNumbers.Length; i++)
                {
                    if (activeCardNumbers[i] > passiveCardNumbers[i])
                    {
                        result = true;
                        break;
                    }
                    else if (activeCardNumbers[i] == passiveCardNumbers[i])
                    {
                        continue;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }

            }
            else if (activeType == CardsTypeEnum.对对)
            {
                int[] activeCardNumbers = new int[activeCards.Count];
                for (int i = 0; i < activeCards.Count; i++)
                {
                    activeCardNumbers[i] = (int)activeCards[i].cardNumber;
                }

                int[] passiveCardNumbers = new int[passiveCards.Count];
                for (int i = 0; i < passiveCards.Count; i++)
                {
                    passiveCardNumbers[i] = (int)passiveCards[i].cardNumber;
                }
                int activeDuiNumber = 0;
                for (int i = 0; i < activeCardNumbers.Length; i++)
                {
                    for (int j = i + 1; j < activeCardNumbers.Length - 1; j++)
                    {
                        if (activeCardNumbers[i] == activeCardNumbers[j])
                        {
                            activeDuiNumber = activeCardNumbers[i];
                        }
                        else if (activeCardNumbers[j] == activeCardNumbers[j + 1])
                        {
                            activeDuiNumber = activeCardNumbers[j];
                        }
                    }
                }
                int passiveDuiNumber = 0;
                for (int i = 0; i < passiveCardNumbers.Length; i++)
                {
                    for (int j = i + 1; j < passiveCardNumbers.Length - 1; j++)
                    {
                        if (passiveCardNumbers[i] == passiveCardNumbers[j])
                        {
                            passiveDuiNumber = passiveCardNumbers[i];
                        }
                        else if (passiveCardNumbers[j] == passiveCardNumbers[j + 1])
                        {
                            passiveDuiNumber = passiveCardNumbers[j];
                        }
                    }
                }
                if (activeDuiNumber > passiveDuiNumber)
                {
                    result = true;
                }
                else if (activeDuiNumber == passiveDuiNumber)
                {
                    int activePlus = 0;
                    for (int i = 0; i < activeCardNumbers.Length; i++)
                    {
                        activePlus += activeCardNumbers[i];
                    }
                    int passivePlus = 0;
                    for (int i = 0; i < passiveCardNumbers.Length; i++)
                    {
                        passivePlus += passiveCardNumbers[i];
                    }
                    if (activePlus > passivePlus)
                    {
                        result = true;
                    }
                }
            }
        }
        return result;
    }
}
