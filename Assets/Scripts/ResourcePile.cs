
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;

    // backing field for production speed
    // private member variable
    private float m_ProductionSpeed = 0.5f;

    public float ProductionSpeed
    {
        // the 'getter' returns the current value of m_ProductionSpeed
        get
        {
            return m_ProductionSpeed;
        }

        // the 'setter' sets the value of m_ProductionSpeed to its new value
        set
        {
            // first check to see if the new value to be set is negative
            if (value < 0f)
            {
                // if it is
                // display a warning message
                // and return
                Debug.LogError("YOU CANNOT SET A NEGATIVE PRODUCTION SPEED!");
            }

            // otherwise
            else
            {
                // assign the new value to m_ProductionSpeed
                m_ProductionSpeed = value;
            }
        }
    }

    private float m_CurrentProduction = 0.0f;




    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += ProductionSpeed * Time.deltaTime;
        }
    }


    public override string GetData()
    {
        return $"Producing at the speed of {ProductionSpeed}/s";
        
    }
    
    
} // end of class
