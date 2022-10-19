import { ref, computed } from "vue";
import type { Display } from "@/models/display.model";
import { defineStore } from "pinia";

export const useCrestronStore = defineStore("crestron", {
  state: () => ({
    displays: Display[]
  }),
  getters: {

  },
  actions: {

  }
});
