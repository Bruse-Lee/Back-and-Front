<template>
  <div class="icon">
    
      <icon-scissors />
      <icon-heart-face />
      <icon-watch />
      <icon-palette />
    
  </div>
</template>

<script>
import IconWatch from "./animatedicons/IconWatch.vue";
import IconPalette from "./animatedicons/IconPalette.vue";
import IconScissors from "./animatedicons/IconScissors.vue";
import IconHeartFace from "./animatedicons/IconHeartFace.vue";

export default {
  components: {
    IconWatch,
    IconPalette,
    IconScissors,
    IconHeartFace,
  },
};
</script>

<style scoped>
svg {
  cursor: pointer;
}
.icon{
  
  margin-left: 35%;

}
</style>