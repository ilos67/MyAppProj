export interface KeyValuePair { 
  id: number; 
  name: string; 
}

export interface Ingredients {
  protein: number;
  calori: number;
  fat: number;
}

export interface Vehicle {
  id: number; 
  model: KeyValuePair;
  make: KeyValuePair;
  isRegistered: boolean;
  features: KeyValuePair[];
  ingredients: Ingredients;
  lastUpdate: string; 
}

export interface SaveVehicle {
  id: number; 
  modelId: number;
  makeId: number;
  isRegistered: boolean;
  features: number[];
  ingredients: Ingredients;
}