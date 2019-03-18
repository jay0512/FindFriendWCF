/**
 * ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package com.microsoft.schemas._2003._10.Serialization.Arrays;

public class ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T  implements java.io.Serializable {
    private org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User key;

    private int value;

    public ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T() {
    }

    public ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T(
           org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User key,
           int value) {
           this.key = key;
           this.value = value;
    }


    /**
     * Gets the key value for this ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T.
     * 
     * @return key
     */
    public org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User getKey() {
        return key;
    }


    /**
     * Sets the key value for this ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T.
     * 
     * @param key
     */
    public void setKey(org.datacontract.schemas._2004._07.WCFMutualFriendSuggetionService.User key) {
        this.key = key;
    }


    /**
     * Gets the value value for this ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T.
     * 
     * @return value
     */
    public int getValue() {
        return value;
    }


    /**
     * Sets the value value for this ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T.
     * 
     * @param value
     */
    public void setValue(int value) {
        this.value = value;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T)) return false;
        ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T other = (ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            ((this.key==null && other.getKey()==null) || 
             (this.key!=null &&
              this.key.equals(other.getKey()))) &&
            this.value == other.getValue();
        __equalsCalc = null;
        return _equals;
    }

    private boolean __hashCodeCalc = false;
    public synchronized int hashCode() {
        if (__hashCodeCalc) {
            return 0;
        }
        __hashCodeCalc = true;
        int _hashCode = 1;
        if (getKey() != null) {
            _hashCode += getKey().hashCode();
        }
        _hashCode += getValue();
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(ArrayOfKeyValueOfUserintCL4X437TKeyValueOfUserintCL4X437T.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://schemas.microsoft.com/2003/10/Serialization/Arrays", ">ArrayOfKeyValueOfUserintCL4x437T>KeyValueOfUserintCL4x437T"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("key");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.microsoft.com/2003/10/Serialization/Arrays", "Key"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://schemas.datacontract.org/2004/07/WCFMutualFriendSuggetionService", "User"));
        elemField.setNillable(true);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("value");
        elemField.setXmlName(new javax.xml.namespace.QName("http://schemas.microsoft.com/2003/10/Serialization/Arrays", "Value"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
    }

    /**
     * Return type metadata object
     */
    public static org.apache.axis.description.TypeDesc getTypeDesc() {
        return typeDesc;
    }

    /**
     * Get Custom Serializer
     */
    public static org.apache.axis.encoding.Serializer getSerializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new  org.apache.axis.encoding.ser.BeanSerializer(
            _javaType, _xmlType, typeDesc);
    }

    /**
     * Get Custom Deserializer
     */
    public static org.apache.axis.encoding.Deserializer getDeserializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new  org.apache.axis.encoding.ser.BeanDeserializer(
            _javaType, _xmlType, typeDesc);
    }

}
