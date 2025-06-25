
using UnityEngine;


public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;

    public float ProductivityMultiplier = 2;




    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;

                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }


    public void ResetProductivity()
    {
        // if there is no current pile
        if (m_CurrentPile != null)
        {
            // reset the current pile's production speed
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;

            // and set the current pile to null
            m_CurrentPile = null;
        }
    }


    public virtual void Goto(Building target)
    {
        // call the resetproductivity method
        ResetProductivity();

        // call the goto(building) method in the base class
        base.GoTo(target);
    }


    public virtual void Goto(Vector3 position)
    {
        ResetProductivity();

        // call the goto(position) method in the base class
        base.GoTo(position);
    }


} // end of class
