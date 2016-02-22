﻿using System;
using System.Threading;
using ColossalFramework.Math;
using Transit.Framework.Light;

namespace CSL_Traffic
{
    public static class PathManagerExtensions
    {
        public static bool CreatePath(this PathManager pm, out uint unit, ref Randomizer randomizer, uint buildIndex, PathUnit.Position startPos, PathUnit.Position endPos, NetInfo.LaneType laneTypes, VehicleInfo.VehicleType vehicleTypes, float maxLength, ExtendedVehicleType vehicleType)
        {
            PathUnit.Position position = default(PathUnit.Position);
            return pm.CreatePath(out unit, ref randomizer, buildIndex, startPos, position, endPos, position, position, laneTypes, vehicleTypes, maxLength, false, false, false, false, vehicleType);
        }

        public static bool CreatePath(this PathManager pm, out uint unit, ref Randomizer randomizer, uint buildIndex, PathUnit.Position startPosA, PathUnit.Position startPosB, PathUnit.Position endPosA, PathUnit.Position endPosB, NetInfo.LaneType laneTypes, VehicleInfo.VehicleType vehicleTypes, float maxLength, ExtendedVehicleType vehicleType)
        {
            return pm.CreatePath(out unit, ref randomizer, buildIndex, startPosA, startPosB, endPosA, endPosB, default(PathUnit.Position), laneTypes, vehicleTypes, maxLength, false, false, false, false, vehicleType);
        }

        public static bool CreatePath(this PathManager pm, out uint unit, ref Randomizer randomizer, uint buildIndex, PathUnit.Position startPosA, PathUnit.Position startPosB, PathUnit.Position endPosA, PathUnit.Position endPosB, NetInfo.LaneType laneTypes, VehicleInfo.VehicleType vehicleTypes, float maxLength, bool isHeavyVehicle, bool ignoreBlocked, bool stablePath, bool skipQueue, ExtendedVehicleType vehicleType)
        {
            return pm.CreatePath(out unit, ref randomizer, buildIndex, startPosA, startPosB, endPosA, endPosB, default(PathUnit.Position), laneTypes, vehicleTypes, maxLength, isHeavyVehicle, ignoreBlocked, stablePath, skipQueue, vehicleType);
        }

        public static bool CreatePath(this PathManager pm, out uint unit, ref Randomizer randomizer, uint buildIndex, PathUnit.Position startPosA, PathUnit.Position startPosB, PathUnit.Position endPosA, PathUnit.Position endPosB, PathUnit.Position vehiclePosition, NetInfo.LaneType laneTypes, VehicleInfo.VehicleType vehicleTypes, float maxLength, bool isHeavyVehicle, bool ignoreBlocked, bool stablePath, bool skipQueue, ExtendedVehicleType vehicleType)
        {
            while (!Monitor.TryEnter(pm.m_bufferLock, SimulationManager.SYNCHRONIZE_TIMEOUT))
            {
            }
            uint num;
            try
            {
                if (!pm.m_pathUnits.CreateItem(out num, ref randomizer))
                {
                    unit = 0u;
                    bool result = false;
                    return result;
                }
                pm.m_pathUnitCount = (int)(pm.m_pathUnits.ItemCount() - 1u);
            }
            finally
            {
                Monitor.Exit(pm.m_bufferLock);
            }
            unit = num;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_simulationFlags = 1;
            if (isHeavyVehicle)
            {
                PathUnit[] expr_92_cp_0 = pm.m_pathUnits.m_buffer;
                UIntPtr expr_92_cp_1 = (UIntPtr)unit;
                expr_92_cp_0[(int)expr_92_cp_1].m_simulationFlags = (byte)(expr_92_cp_0[(int)expr_92_cp_1].m_simulationFlags | 16);
            }
            if (ignoreBlocked)
            {
                PathUnit[] expr_BB_cp_0 = pm.m_pathUnits.m_buffer;
                UIntPtr expr_BB_cp_1 = (UIntPtr)unit;
                expr_BB_cp_0[(int)expr_BB_cp_1].m_simulationFlags = (byte)(expr_BB_cp_0[(int)expr_BB_cp_1].m_simulationFlags | 32);
            }
            if (stablePath)
            {
                PathUnit[] expr_E4_cp_0 = pm.m_pathUnits.m_buffer;
                UIntPtr expr_E4_cp_1 = (UIntPtr)unit;
                expr_E4_cp_0[(int)expr_E4_cp_1].m_simulationFlags = (byte)(expr_E4_cp_0[(int)expr_E4_cp_1].m_simulationFlags | 64);
            }
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_pathFindFlags = 0;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_buildIndex = buildIndex;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_position00 = startPosA;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_position01 = endPosA;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_position02 = startPosB;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_position03 = endPosB;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_position11 = vehiclePosition;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_nextPathUnit = 0u;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_laneTypes = (byte)laneTypes;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_vehicleTypes = (byte)vehicleTypes;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_length = maxLength;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_positionCount = 20;
            pm.m_pathUnits.m_buffer[(int)((UIntPtr)unit)].m_referenceCount = 1;
            int num2 = 10000000;
            CustomPathFind pathFind = null;
            if (CustomPathManager.m_pathfinds != null)
            {
                for (int i = 0; i < CustomPathManager.m_pathfinds.Length; i++)
                {
                    CustomPathFind pathFind2 = CustomPathManager.m_pathfinds[i];
                    if (pathFind2.IsAvailable && pathFind2.m_queuedPathFindCount < num2)
                    {
                        num2 = pathFind2.m_queuedPathFindCount;
                        pathFind = pathFind2;
                    }
                }
            }
            if (pathFind != null && pathFind.CalculatePath(unit, skipQueue, vehicleType))
            {
                return true;
            }
            pm.ReleasePath(unit);
            return false;
        }
    }
}