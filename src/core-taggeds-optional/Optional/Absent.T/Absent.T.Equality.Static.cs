﻿#pragma warning disable IDE0060 // Remove unused parameter

namespace System;

partial struct Absent<T>
{
    public static bool Equals(Absent<T> left, Absent<T> right) => true;

    public static bool operator ==(Absent<T> left, Absent<T> right) => true;

    public static bool operator !=(Absent<T> left, Absent<T> right) => false;
}
