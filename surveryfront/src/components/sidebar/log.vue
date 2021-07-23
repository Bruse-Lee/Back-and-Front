<template>
  <div>
    <el-card class="box-card">
      <el-form :inline="true" class="demo-form-inline">
        <el-form-item label="审批人">
          <el-input placeholder="审批人"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button>查询</el-button>
        </el-form-item>
        <el-form-item>
          <el-button type="primary">新增</el-button>
        </el-form-item>
      </el-form>
    </el-card>
    <el-table :data="tableData" style="width: 100%" border>
      <el-table-column label="Id" align="center">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{ scope.row.id }}</span>
        </template>
      </el-table-column>
      <el-table-column label="客户端地址" align="center">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{ scope.row.clientIpAddress }}</span>
        </template>
      </el-table-column>
      <el-table-column label="执行时间" align="center">
        <template slot-scope="scope">
          <el-popover trigger="hover" placement="top">
            <p>参数: {{ scope.row.parameters }}</p>
            <p>返回数据: {{ scope.row.returnValue }}</p>
            <p>服务名称: {{ scope.row.serviceName }}</p>
            <p>方法名称: {{ scope.row.methodName }}</p>
            <div slot="reference" class="name-wrapper">
              <el-tag size="medium">{{ scope.row.executionDuration }}</el-tag>
            </div>
          </el-popover>
        </template>
      </el-table-column>
      <el-table-column label="创建时间" align="center">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{ scope.row.createdTime }}</span>
        </template>
      </el-table-column>

      <el-table-column label="备注" align="center">
        <template slot-scope="scope">
          <i class="el-icon-time"></i>
          <span style="margin-left: 10px">{{ scope.row.remarks }}</span>
        </template>
      </el-table-column>
      <el-table-column label="操作" width="180px" align="center">
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)"
            >编辑</el-button
          >
          <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.$index, scope.row)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <!-- 分页组件 -->
    <div class="block">
      <el-pagination
        :current-page="pager.pageIndex"
        :page-size="pager.pageSize"
        layout="prev, pager, next, jumper,sizes, total"
        :total="pager.rowsTotal"
        @current-change="handlePageIndexChange"
        @size-change="handlePageSizeChange"
      >
      </el-pagination>
    </div>
  </div>
</template>

<script>
// import GetList from "../../api/user";
// import { getAudit } from "../../api/log";
export default {
  data() {
    return {
      tableData: [],
      pager: {
        pageIndex: 1, // 页码
        pageSize: 10, // 页面大小（每页项目的数量）
        rowsTotal: 30, // 总记录数
      },
    };
  },

  methods: {
    handleEdit(index, row) {
      console.log(index, row);
    },
    handleDelete(index, row) {
      console.log(index, row);
    },
    // 改变页码后，重新拉取数据
    handlePageIndexChange(val) {
      this.pager.pageIndex = val;
      this.fetchData(this.pager);
      console.log(val);
    },
    // 改变页大小后，重新拉取数据
    handlePageSizeChange(val) {
      this.pager.pageSize = val;
      this.fetchData(this.pager);
      console.log(val);
    },
    // 拉取数据方法
    // fetchData(pager) {
    //   getAudit(pager)
    //     .then((data) => {
    //       let res = data.data;
    //       console.log(res);
    //       this.tableData = res.data;
    //       this.pager = res.pager;
    //     })
    //     .catch((err) => {
    //       console.log(err);
    //     });
    // },
  },
  mounted() {
    this.fetchData(this.pager);
  },
};
</script>

<style scoped>
</style>