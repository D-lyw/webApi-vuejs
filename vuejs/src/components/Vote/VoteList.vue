<template>
    <div style="display:flex;flex-direction: row;flex-wrap:wrap;">
        <el-card class="box-card" 
            v-for="(obj, index) in msgList"
            :key="index" >
            <div slot="header" class="clearfix">
                <span>{{obj.Title}}</span>
                <el-button style="float: right; padding: 3px 0" type="text" @click="goToClick(obj.ItemId)">进入投票</el-button>
            </div>
            <div v-for="o in obj.Items" :key="o" class="text item">
                {{o}}
            </div>
            <el-rate
                v-model="randomArr[index % 20]"
                disabled
                show-score
                text-color="#ff9900"
                score-template="{value}">
            </el-rate>
        </el-card>
    </div>
</template>

<script>
export default {
    name: 'voteList',
    data(){
        return {
            msgList: [],
            value5: 3.7,
            randomArr: []
        }
    },
    mounted() {
        this.getVoteItemLists();
        for(var i = 0; i < 20; i++){
            this.randomArr.push(parseFloat((Math.random() * 2).toFixed(1)) + 3 );
        }
    },
    methods: {
        getVoteItemLists(){
            this.axios.post(this.url + '/GetVoteList')
                .then((data) => {
                    console.log(data);
                    this.msgList = data.data;
                })
                .catch((err) => {

                })
        },
        goToClick(id){
            // 传递item的ID
            this.$router.push('/home/votedetail/'+ id);
        }
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
    /* display: inline-block; */
    margin: 10px 10px;
  }

  .cardName{
      text-align: left;
  }
</style>
