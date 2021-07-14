<template>
  <div>
    <label for="Username">Username:</label>
    <input type="text" />
    <br />
    <br />
    <label for="Password">Password:</label>
    <input type="text" />
    <br />
    <br />
    <label for="Password">ConfirmPwd:</label>
    <input type="text" />
    <br />
    <br />
    <button>注册</button>
    &nbsp;&nbsp;
    <button @click="Cancel">取消</button>
  </div>
</template>

<script>
export default {
  methods: {
    Cancel() {
      this.$router.push({ path: "/Login" });
    },
  },
};
</script>

<style scoped>
label {
  color: black;
}
</style>