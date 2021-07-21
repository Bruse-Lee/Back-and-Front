<template>
  <div class="icon">
    <icon-scissors />
    <icon-heart-face />
    <icon-watch />
    <icon-palette />
    <h1>千万别碰他们哟~他们会有反应哒!</h1>
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
.icon {
  margin-left: 35%;
}
h1 {
  font-weight: 900;
  font-family: fantasy;
}
</style>