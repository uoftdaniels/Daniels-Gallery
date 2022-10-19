export const enum ProjectorState {
  None = 0,
  WarmingUp = 1,
  CollingDown = 2,
}

export interface Display {
  id: string;
  name: string;
  power: boolean;
  state: ProjectorState;
  lamp: number;
}
