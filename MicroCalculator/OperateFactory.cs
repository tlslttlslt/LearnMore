//�����������Ǹ��ݵ���Ĳ�����������ʹ���ĸ���ʵ�����ӿ�
//����ʵ��operInterfate()�ӿ�,ʵ�ֵķ�������OperateAdd()����ʵ��

using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public  class OperateFactory
    {
        public OperateFactory()
        { 
            //TODO Counstruct Method
        }
        public OperateInterface CreateOperate(string strOperator)
        {
            if (strOperator.Equals("+"))
            {
                OperateInterface operInterf = new OperateAdd();                   //�������������+������һ���ӿ�operInterf������ʹ��OperateAdd()��ʵ��������ӿ�
                //��ʱoperInterf��ʵ����һ��OperateAdd()�Ķ���
                return operInterf;//��ʱ��operInterf���ظ�operFac.CreateOperate(),�ٸ�ֵ��operInterface
            
            }

            else if (strOperator.Equals("-"))
            {
                OperateInterface operInterf = new OperateDec();
                return operInterf;

            }


            else if (strOperator.Equals("*"))
            {
                OperateInterface operInterf = new OperateRide();
                return operInterf;

            }

            else if(strOperator.Equals("/"))
            {
                OperateInterface operInterf = new OperateDiv();
                return operInterf;

            }

            else if (strOperator.Equals("reciprocal"))
            {
                OperateInterface operInterf = new OperateRecip();
                return operInterf;
            
            }
            return null;
            
        }



    }
}
