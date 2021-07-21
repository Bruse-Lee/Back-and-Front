<template>
  <div class="img-box">
    <el-carousel :interval="4000" type="card" height="730px" width="100%">
      <el-carousel-item v-for="item in List" :key="item.key">
        <h3 class="medium">
          <img :src="item.url" />
        </h3>
      </el-carousel-item>
    </el-carousel>
  </div>
</template>

<script>
export default {
  data() {
    return {
      List: [
        {
          key: "Photo",
          url: require("../../imgs/keyboard.png"),
          desc: "keyboardHander",
        },
        {
          key: "Photo2",
          url: require("../../imgs/Foreast.jpg"),
          desc: "Foreast",
        },
        {
          key: "Photo3",
          url: require("../../imgs/Scar.jpg"),
          desc: "Scar",
        },
      ],
    };
  },
};
</script>

<style>
.img-box{
    width: 100%;
}
img{
    height: 100%;
    /* width: 100%; */
}
.el-carousel__item h3 {
  color: #475669;
  font-size: 14px;
  opacity: 0.75;
  line-height: 200px;
  margin: 0;
}

.el-carousel__item:nth-child(2n) {
  background-color: #99a9bf;
}

.el-carousel__item:nth-child(2n + 1) {
  background-color: #d3dce6;
}
</style>