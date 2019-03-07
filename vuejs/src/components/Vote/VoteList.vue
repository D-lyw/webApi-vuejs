<template>
    <div>
        <el-card class="box-card">
            <div slot="header" class="clearfix">
                <span>卡片名称</span>
                <el-button style="float: right; padding: 3px 0" type="text">进入投票</el-button>
            </div>
            <div v-for="o in 4" :key="o" class="text item">
                {{'列表内容 ' + o }}
            </div>
        </el-card>

        <el-card class="box-card">
            <div slot="header" class="clearfix">
                <span class="cardName">卡片名称</span>
                <el-button style="float: right; padding: 3px 0" type="text">进入投票</el-button>
            </div>
            <div v-for="o in 4" :key="o" class="text item">
                {{'列表内容 ' + o }}
            </div>
        </el-card> <el-card class="box-card">
            <div slot="header" class="clearfix">
                <span class="cardName">卡片名称</span>
                <el-button style="float: right; padding: 3px 0" type="text">进入投票</el-button>
            </div>
            <div v-for="o in 4" :key="o" class="text item">
                {{'列表内容 ' + o }}
            </div>
        </el-card> <el-card class="box-card">
            <div slot="header" class="clearfix">
                <span class="cardName">卡片名称</span>
                <el-button style="float: right; padding: 3px 0" type="text">进入投票</el-button>
            </div>
            <div v-for="o in 4" :key="o" class="text item">
                {{'列表内容 ' + o }}
            </div>
        </el-card>
    </div>
</template>

<script>
export default {
    name: 'voteList',
    data(){
        return {

        }
    },
    methods: {

    }
}
</script>

<style scoped>
  .text {
    font-size: 14px;
    text-align: left
  }

  .item {
    margin-bottom: 18px;
  }

  .clearfix:before,
  .clearfix:after {
    display: table;
    content: "";
  }
  .clearfix:after {
    clear: both
  }

  .box-card {
    width: 465px;
    display: inline-block;
    margin: 10px 20px;
  }

  .cardName{
      text-align: left;
  }
</style>
