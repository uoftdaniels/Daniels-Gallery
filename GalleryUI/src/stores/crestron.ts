import { defineStore } from "pinia";
import type { Display } from "@/models/display.model";

type StoreState = {
  displays: Display[];
};

export const useCrestronStore = defineStore("crestron", {
  state: (): StoreState => ({
    displays: [] as Display[],
  }),
  getters: {},
  actions: {
    powerOn(id: string) {
      const index = this.findIndexById(id);
      if (index !== -1) {
        this.displays[index].power = true;
      }
    },
    findIndexById(id: string) {
      return this.displays.findIndex((display) => display.id === id);
    },
  },
});
